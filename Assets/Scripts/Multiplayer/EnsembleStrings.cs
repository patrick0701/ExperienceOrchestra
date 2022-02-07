using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.Audio;
using System;
using Normal.Realtime;

public class EnsembleStrings : MonoBehaviour
{
    public BowTrigger bowTrigger;
    public bool instrumentGrabbed;
    public InputActionProperty velocityProperty;
    public float playVelocityThreshold = 0f;
    public float normalPlayVelocity = 1f;
    public float eps = 0.05f;
    public float minTempo = 0.8f;
    public float maxTempo = 1.2f;
    public int maxWinLength = 200;
    public AudioSource audioSource;
    public NetworkedAudio networkedAudio;
    public float stopEps = 0.05f;

    private Vector3 velocity;
    private bool alreadyPlaying;

    private float avgMagnitude;
    private float[] magnitudes;
    private int curWinLength = 0;
    private int curWinIdx = 0;

    private RealtimeTransform realtimeTransform;

    private void Start()
    {
        magnitudes = new float[maxWinLength];
        for (int i = 0; i < maxWinLength; i++)
        {
            magnitudes[i] = 0f;
        }

        realtimeTransform = GetComponent<RealtimeTransform>();
        networkedAudio = GetComponent<NetworkedAudio>();
    }

    private void Update()
    {
        if (!realtimeTransform.isOwnedLocallyInHierarchy)
            return;

        velocity = velocityProperty.action.ReadValue<Vector3>();
        HandlePlaying();
    }

    public void SetGrabbed(bool grabbed)
    {
        instrumentGrabbed = grabbed;
    }

    private void HandlePlaying()
    {
        bool play = instrumentGrabbed && (velocity.magnitude > playVelocityThreshold)
            && bowTrigger.BowIsTouching();
        bool stopPlaying = !instrumentGrabbed || !bowTrigger.BowIsTouching()
            || (avgMagnitude <= stopEps);

        if (!alreadyPlaying && play)
        {
            // Start the music
            alreadyPlaying = true;
            //onPlayEvent?.Invoke();
            networkedAudio.SetIsPlaying(true);
        }
        else if (alreadyPlaying && stopPlaying)
        {
            // Stop the music
            alreadyPlaying = false;
            //onStopEvent?.Invoke();
            avgMagnitude = 0f;
            curWinIdx = curWinLength = 0;
            networkedAudio.SetIsPlaying(false);
            networkedAudio.SetSpeedFraction(1f);
        }

        if (alreadyPlaying)
        {
            HandleTempo();
            networkedAudio.SetAudioTime(audioSource.time);
        }
    }

    private void HandleTempo()
    {
        UpdateAvgMagnitude();
        if (curWinLength < maxWinLength)
            return;

        bool isSpeedDifferent = (Mathf.Abs(avgMagnitude - normalPlayVelocity) >= eps);
        float speedFrac = Mathf.Clamp(avgMagnitude / normalPlayVelocity, minTempo, maxTempo);

        speedFrac = (isSpeedDifferent) ? speedFrac : 1f;

        networkedAudio.SetSpeedFraction(speedFrac);
    }

    private void UpdateAvgMagnitude()
    {
        float curMagnitude = velocity.magnitude;

        magnitudes[curWinIdx] = curMagnitude;
        curWinIdx = (curWinIdx + 1) % maxWinLength;
        float sum = 0;
        Array.ForEach(magnitudes, delegate (float x) { sum += x; });

        if (curWinLength < maxWinLength)
        {
            curWinLength += 1;
        }

        avgMagnitude = sum / curWinLength;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.Audio;
using System;

public class PlayStrings : MonoBehaviour
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
    public float stopEps = 0.05f;

    public UnityEvent onPlayEvent;
    public UnityEvent onStopEvent;

    private Vector3 velocity;
    private bool alreadyPlaying;

    private float avgMagnitude;
    private float[] magnitudes;
    private int curWinLength = 0;
    private int curWinIdx = 0;

    private void Start()
    {
        magnitudes = new float[maxWinLength];
        for (int i = 0; i < maxWinLength; i++)
        {
            magnitudes[i] = 0f;
        }
    }

    private void Update()
    {
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
            onPlayEvent?.Invoke();
        }
        else if (alreadyPlaying && stopPlaying)
        {
            // Stop the music
            alreadyPlaying = false;
            onStopEvent?.Invoke();
            avgMagnitude = 0f;
            curWinIdx = curWinLength = 0;
        }

        if (alreadyPlaying)
        {
            HandleTempo();
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
        audioSource.pitch = speedFrac;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("PitchBend", 1f / speedFrac);
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

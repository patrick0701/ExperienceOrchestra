using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayWinds : MonoBehaviour
{
    public WindTrigger windTrigger;
    public HandTrigger handTrigger;
    public bool instrumentGrabbed;
    public float normalPressRate = 1f;
    public float pressRateThreshold = 0.001f;
    public float eps = 0.05f;
    public float minTempo = 0.8f;
    public float maxTempo = 1.2f;
    public int maxWinLength = 200;
    public AudioSource audioSource;
    public float stopEps = 0.05f;
    public float perFrame = 60f;

    public UnityEvent onPlayEvent;
    public UnityEvent onStopEvent;

    public List<InputActionReference> buttonPressInputs;
    private float avgPressRate;
    private float curPressRate;
    private float pressCount;
    private float[] pressRates;
    private int curWinLength = 0;
    private int curWinIdx = 0;

    private bool alreadyPlaying;

    private int curFrame = 0;

    private void Start()
    {
        pressCount = 0;
        pressRates = new float[maxWinLength];

        for (int i = 0; i < maxWinLength; i++)
        {
            pressRates[i] = 0f;
        }

        foreach (InputActionReference actionReference in buttonPressInputs)
        {
            actionReference.action.started += OnPressPerformed;
        }
    }

    private void Update()
    {
        HandlePressCalculation();
        HandlePlaying();
    }

    public void SetGrabbed(bool grabbed)
    {
        instrumentGrabbed = grabbed;
    }

    private void HandlePressCalculation()
    {
        if (curFrame >= perFrame)
        {
            CalculatePressRate();
        }

        curFrame += 1;
    }

    private void OnPressPerformed(CallbackContext context)
    {
        pressCount += 1;
    }
    
    private void CalculatePressRate()
    {
        curPressRate = pressCount / perFrame;
        pressCount = 0;
    }

    private void HandlePlaying()
    {
        bool play = instrumentGrabbed && windTrigger.PlayerTouching() 
            && handTrigger.PlayerIsTouching() && (curPressRate > pressRateThreshold);
        bool stopPlaying = !instrumentGrabbed || !windTrigger.PlayerTouching() 
            || !handTrigger.PlayerIsTouching() || avgPressRate <= stopEps;

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
            avgPressRate = 0;
            curWinIdx = curWinLength = 0;
        }

        if (alreadyPlaying)
        {
            HandleTempo();
        }
    }

    private void HandleTempo()
    {
        UpdateAvgPressRate();

        if (curWinLength < maxWinLength)
            return;

        bool isSpeedDifferent = (Mathf.Abs(avgPressRate - normalPressRate) >= eps);
        float speedFrac = Mathf.Clamp(avgPressRate / normalPressRate, minTempo, maxTempo);

        speedFrac = (isSpeedDifferent) ? speedFrac : 1f;
        audioSource.pitch = speedFrac;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("PitchBend", 1f / speedFrac);
    }

    private void UpdateAvgPressRate()
    {
        pressRates[curWinIdx] = curPressRate;
        curWinIdx = (curWinIdx + 1) % maxWinLength;
        float sum = 0;
        Array.ForEach(pressRates, delegate (float x) { sum += x; });

        if (curWinLength < maxWinLength)
        {
            curWinLength += 1;
        }

        avgPressRate = sum / curWinLength;
    }
}

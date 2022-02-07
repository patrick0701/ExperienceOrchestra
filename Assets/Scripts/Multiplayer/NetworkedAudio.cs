using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class NetworkedAudio : RealtimeComponent<NetworkedAudioModel>
{
    [SerializeField] AudioSource audioSource;
    private float audioTime = 0;
    private float speedFrac = 1;
    private bool isPlaying;

    public UnityEvent onPlayEvent;
    public UnityEvent onStopEvent;

    private void Start()
    {

    }

    private void Update()
    {

    }

    protected override void OnRealtimeModelReplaced(NetworkedAudioModel previousModel, NetworkedAudioModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.audioTimeDidChange -= AudioTimeDidChange;
            previousModel.speedFractionDidChange -= SpeedFractionDidChange;
            previousModel.isPlayingDidChange -= IsPlayingDidChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.audioTime = audioTime;
                currentModel.speedFraction = speedFrac;
                currentModel.isPlaying = isPlaying;
            }

            UpdateAudioTime();
            UpdateSpeedFraction();
            UpdateIsPlaying();

            currentModel.audioTimeDidChange += AudioTimeDidChange;
            currentModel.speedFractionDidChange += SpeedFractionDidChange;
            currentModel.isPlayingDidChange += IsPlayingDidChange;
        }
    }

    private void AudioTimeDidChange(NetworkedAudioModel model, float value)
    {
        UpdateAudioTime();
    }

    private void UpdateAudioTime()
    {
        audioTime = model.audioTime;
        audioSource.time = audioTime;
    }

    public void SetAudioTime(float time)
    {
        model.audioTime = time;
    }

    private void SpeedFractionDidChange(NetworkedAudioModel model, float value)
    {
        UpdateSpeedFraction();
    }

    private void UpdateSpeedFraction()
    {
        speedFrac = model.speedFraction;
        audioSource.pitch = speedFrac;
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("PitchBend", 1f / speedFrac);
    }

    public void SetSpeedFraction(float speedFraction)
    {
        model.speedFraction = speedFraction;
    }

    private void IsPlayingDidChange(NetworkedAudioModel model, bool value)
    {
        UpdateIsPlaying();
    }

    private void UpdateIsPlaying()
    {
        isPlaying = model.isPlaying;

        if (isPlaying)
        {
            //audioSource.Play();
            onPlayEvent?.Invoke();
        }
        else
        {
            //audioSource.Pause();
            onStopEvent?.Invoke();
        }
    }

    public void SetIsPlaying(bool playing)
    {
        model.isPlaying = playing;
    }
}

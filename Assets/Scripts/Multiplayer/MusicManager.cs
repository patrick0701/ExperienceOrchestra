using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class MusicManager : RealtimeComponent<MusicManagerModel>
{
    private static MusicManager instance;
    public static MusicManager Instance { get { return instance;  } }

    private float globalMusicTime = -1;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    protected override void OnRealtimeModelReplaced(MusicManagerModel previousModel, MusicManagerModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.globalMusicTimeDidChange -= GlobalMusicTimeDidChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.globalMusicTime = globalMusicTime;
            }

            UpdateGlobalMusicTime();

            currentModel.globalMusicTimeDidChange += GlobalMusicTimeDidChange;
        }
    }

    private void GlobalMusicTimeDidChange(MusicManagerModel mode, float value)
    {
        UpdateGlobalMusicTime();
    }

    private void UpdateGlobalMusicTime()
    {
        globalMusicTime = model.globalMusicTime;
    }

    public float GetGlobalMusicTime()
    {
        return globalMusicTime;
    }

    public void SetGlobalMusicTime(float value)
    {
        model.globalMusicTime = value;
    }
}

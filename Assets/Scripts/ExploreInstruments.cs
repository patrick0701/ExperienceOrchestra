using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreInstruments : MonoBehaviour
{
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void BackClick()
    {
        SceneManager.LoadSceneAsync("MainMenuUI");
    }

    public void StringClick()
    {
        gameManager.UpdateInstrumentGroup("strings");
        SceneManager.LoadSceneAsync("PlayInstrumentScene");
    }

    public void WindClick()
    {
        gameManager.UpdateInstrumentGroup("winds");
        SceneManager.LoadSceneAsync("PlayInstrumentScene");
    }

    public void BrassClick()
    {
        gameManager.UpdateInstrumentGroup("brass");
        SceneManager.LoadSceneAsync("PlayInstrumentScene");
    }

    public void PercussionClick()
    {
        gameManager.UpdateInstrumentGroup("percussion");
        SceneManager.LoadSceneAsync("PlayInstrumentScene");
    }

}

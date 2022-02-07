using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentDisplay : MonoBehaviour
{
    public List<GameObject> Strings;
    public List<GameObject> Winds;
    public List<GameObject> Brass;
    public List<GameObject> Percussion;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void StringsOn()
    {
        for (int i = 0; i < Strings.Count; ++i)
        {
            Strings[i].SetActive(true);
        }
        for (int i = 0; i < Winds.Count; ++i)
        {
            Winds[i].SetActive(false);
        }
        for (int i = 0; i < Brass.Count; ++i)
        {
            Brass[i].SetActive(false);
        }
        for (int i = 0; i < Percussion.Count; ++i)
        {
            Percussion[i].SetActive(false);
        }
    }

    void WindsOn()
    {
        for (int i = 0; i < Strings.Count; ++i)
        {
            Strings[i].SetActive(false);
        }
        for (int i = 0; i < Winds.Count; ++i)
        {
            Winds[i].SetActive(true);
        }
        for (int i = 0; i < Brass.Count; ++i)
        {
            Brass[i].SetActive(false);
        }
        for (int i = 0; i < Percussion.Count; ++i)
        {
            Percussion[i].SetActive(false);
        }
    }

    void BrassOn()
    {
        for (int i = 0; i < Strings.Count; ++i)
        {
            Strings[i].SetActive(false);
        }
        for (int i = 0; i < Winds.Count; ++i)
        {
            Winds[i].SetActive(false);
        }
        for (int i = 0; i < Brass.Count; ++i)
        {
            Brass[i].SetActive(true);
        }
        for (int i = 0; i < Percussion.Count; ++i)
        {
            Percussion[i].SetActive(false);
        }
    }

    void PercussionOn()
    {
        for (int i = 0; i < Strings.Count; ++i)
        {
            Strings[i].SetActive(false);
        }
        for (int i = 0; i < Winds.Count; ++i)
        {
            Winds[i].SetActive(false);
        }
        for (int i = 0; i < Brass.Count; ++i)
        {
            Brass[i].SetActive(false);
        }
        for (int i = 0; i < Percussion.Count; ++i)
        {
            Percussion[i].SetActive(true);
        }
    }

    void Start()
    {
        if (gameManager.selectedGroup == "strings")
        {
            StringsOn();
        }
        else if (gameManager.selectedGroup == "winds")
        {
            WindsOn();
        }
        else if (gameManager.selectedGroup == "brass")
        {
            BrassOn();
        }
        else if (gameManager.selectedGroup == "percussion")
        {
            PercussionOn();
        }
    }

    void Update()
    {
        if (gameManager.selectedGroup == "strings")
        {
            StringsOn();
        }
        else if (gameManager.selectedGroup == "winds")
        {
            WindsOn();
        }
        else if (gameManager.selectedGroup == "brass")
        {
            BrassOn();
        }
        else if (gameManager.selectedGroup == "percussion")
        {
            PercussionOn();
        }
    }
}

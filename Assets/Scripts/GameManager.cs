using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string selectedInstrument;
    public string selectedGroup;
    
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void UpdateInstrument(string instrument)
    {
        selectedInstrument = instrument;
    }

    public void UpdateInstrumentGroup(string instrumentGroup)
    {
        selectedGroup = instrumentGroup;
    }
}

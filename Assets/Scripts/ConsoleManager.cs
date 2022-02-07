using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    public TextMeshProUGUI consoleText;

    private static ConsoleManager _instance;

    public static ConsoleManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void Write(string msg)
    {
        consoleText.text = msg;
    }
}
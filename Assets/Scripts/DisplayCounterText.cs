using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCounterText : MonoBehaviour
{
    private int count = 1;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "Not triggered";
    }

    public void increment()
    {
        _text.text = ("Count: " + count++);
    }
}
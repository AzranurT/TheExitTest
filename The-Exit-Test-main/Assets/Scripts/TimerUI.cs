using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private Text timerText;

    void Start()
    {
        timerText = GetComponent<Text>();
    }

    public void UpdateTimer(float currentTime)
    {
        timerText.text = "Odadan ��kmak ��in Kalan Zaman: " + currentTime.ToString("F1");
    }
}

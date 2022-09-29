using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;
    public int startMinutes;
    public TextMeshProUGUI currentTimeText;

    private void Start()
    {
        currentTime = startMinutes * 60;
    }

    private void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
        }
        currentTimeText.text = currentTime.ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}

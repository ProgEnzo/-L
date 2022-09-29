using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public float multiplier = 5;

    private bool timerActive = false;
    private float currentTime;
    public TextMeshProUGUI currentTimeText;

    private void Start()
    {
        currentTime = 0;
        timerActive = true;
    }

    private void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        score = Mathf.RoundToInt(currentTime * multiplier);
        scoreText.text = score.ToString("Score:" + score);

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString (@"mm\:ss\:fff");
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

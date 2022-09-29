using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class hellFireBar : MonoBehaviour
{
    private Image timerBar;
    public float maxTime;
    private float timeLeft;
    public GameObject TimesUp;

    private void Start()
    {
        TimesUp.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.DOFillAmount(timeLeft / maxTime, duration : 0.15f);
            
            Color newColor = Color.red;
        }
        else 
        {
            TimesUp.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

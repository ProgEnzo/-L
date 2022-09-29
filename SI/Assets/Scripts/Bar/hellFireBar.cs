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
    
    //Appeler nombre de flammes et dire que quand celui-ci s'incrémente de 1 la Hellbar s'aincrémente de 33% de la valeur initiale de maxTimer

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
        
        FlagIsCaptured();
    }

    private void FlagIsCaptured()
    {
        if (SO_Controller.nombreDeFlammes == +1)
        {
            timeLeft += maxTime / 3f;
        }
    }
  
}

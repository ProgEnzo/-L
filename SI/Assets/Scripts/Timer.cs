using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
   public bool TimerOn = false;

   public TextMeshProUGUI TimerTxt;

   private void Start()
   {
      TimerOn = true;
   }

   void updateTimer(float currentTime)
   {
      currentTime += 1;

      float minutes = Mathf.FloorToInt(currentTime / 60);
      float seconds = Mathf.FloorToInt(currentTime % 60);
      
   }
}

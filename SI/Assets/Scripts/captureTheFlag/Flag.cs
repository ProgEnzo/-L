using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Flag : MonoBehaviour
{
   public bool takeFlag;

   private void Start()
   {
      takeFlag = false;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         PlayerController.instance.flag = gameObject;
         takeFlag = true;
         other.GetComponent<PlayerController>().GetFlag();

         transform.parent = PlayerController.instance.gameObject.transform;
      }
   }
}

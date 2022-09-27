using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class healthBar : MonoBehaviour
{
    public Image HealthBarImage;
    public PlayerController player;
    
    public void UpdateHealthBar()
    {
        HealthBarImage.fillAmount = Mathf.Clamp(SO_Controller.currentLife / SO_Controller.maxLife, 0, 1f);
    }
}

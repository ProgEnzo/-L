using System;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{
   public float timer;
   [SerializeField] private float maxTimer;
   public Attack attack;
   [SerializeField] private GameObject bullet;

   public static ShootAttack instance;

   void Update()
   {
      if (timer == maxTimer)
      {
         Attack();
         timer = 0;
      }
   }

   private void Awake()
   {
      if (instance != null && instance != this) 
      { 
         Destroy(this); 
      } 
      else 
      { 
         instance = this; 
      }
   }

   void Attack()
   { 
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      float angle = Mathf.Atan2(mousePos.y - PlayerController.instance.transform.position.y, mousePos.x - PlayerController.instance.transform.position.x) * Mathf.Rad2Deg;
      Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
   }
}

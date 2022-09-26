using UnityEngine;

public class ShootAttack : MonoBehaviour
{
   public float timer;
   [SerializeField] private float maxTimer;
   public Attack attack;
   [SerializeField] private GameObject bullet;

   void Update()
   {
      if (timer == maxTimer)
      {
         Attack();
         timer = 0;
      }
   }

   void Attack()
   {
      Instantiate(bullet, transform.position, Quaternion.identity);
   }
}

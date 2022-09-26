using UnityEngine;

public class ShootAttack : MonoBehaviour
{
   [SerializeField] private float timer;
   public float maxTimer;
   [SerializeField] private GameObject bullet;
   void Update()
   {
      if (timer <= 0)
      {
         FireBullet();
         timer = maxTimer;
      }

      timer -= Time.deltaTime;
   }

   void FireBullet()
   {
      Instantiate(bullet, transform.position, Quaternion.identity);
   }
}

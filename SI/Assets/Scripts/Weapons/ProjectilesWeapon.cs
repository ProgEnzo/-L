using UnityEngine;

public class ProjectilesWeapon : Weapon
{
   [SerializeField, Min(1)]
   protected int[] numberOfBullets;
   protected override void Shoot()
   {
      Vector2 direction = _directionShoot.direction.normalized;
      
      GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(0, Vector3.forward));
      
      if (_bullet.GetComponent<Bullet>() != null)
      {
         if (_bullet.GetComponent<ExplosiveBullet>() == null)
         {
            _bullet.GetComponent<Damager>().damages = damages[tierDamages]; 
            _bullet.GetComponent<Bullet>().direction = direction;
         }
         else
         {
            _bullet.GetComponent<ExplosiveBullet>().tempDamage = damages[tierDamages];
            _bullet.GetComponent<Bullet>().direction = direction;
         }
      }
      
      if (numberOfBullets [tierAngles] > 1)
      {
         for (int i = 1; i <= numberOfBullets[tierAngles] / 2; i++)
         {
            _bullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(0, Vector3.forward));
            _bullet.GetComponent<Damager>().damages = damages[tierDamages];
            _bullet.GetComponent<Bullet>().direction = Quaternion.AngleAxis(i * angles[tierAngles] , Vector3.forward)*direction;
            
            _bullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(0, Vector3.forward));
            _bullet.GetComponent<Damager>().damages = damages[tierDamages];
            _bullet.GetComponent<Bullet>().direction = Quaternion.AngleAxis(- i * angles[tierAngles] , Vector3.forward)*direction;
         }
      }
   }
}

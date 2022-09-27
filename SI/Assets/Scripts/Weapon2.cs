using System;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierDamages;

    [Header("Valeurs")]
    [SerializeField] private float[] cooldowns = new float[]{ };
    [SerializeField] float[] damages = new float[] { };

    private float timer;
    [SerializeField] private GameObject bullet2;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Shoot();
            timer = cooldowns[tierCooldowns];
        }
    }

    void Shoot()
    {
        float angle = Mathf.Atan2(DirectionShoot.instance.direction.y - PlayerController.instance.transform.position.y, 
            DirectionShoot.instance.direction.x - PlayerController.instance.transform.position.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bullet2, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        bullet.GetComponent<Bullet>().damages = damages[tierDamages];

        GameObject leftBullet = Instantiate(bullet2, transform.position, Quaternion.AngleAxis(angle + 30f, Vector3.forward));
        leftBullet.GetComponent<Bullet>().damages = damages[tierDamages];
        
        GameObject rightBullet = Instantiate(bullet2, transform.position, Quaternion.AngleAxis(angle - 30f, Vector3.forward));
        rightBullet.GetComponent<Bullet>().damages = damages[tierDamages];
        
        GameObject leftLeftBullet = Instantiate(bullet2, transform.position, Quaternion.AngleAxis(angle + 60f, Vector3.forward));
        leftLeftBullet.GetComponent<Bullet>().damages = damages[tierDamages];

        GameObject rightRightBullet = Instantiate(bullet2, transform.position, Quaternion.AngleAxis(angle - 60f, Vector3.forward));
        rightRightBullet.GetComponent<Bullet>().damages = damages[tierDamages];
    }
}

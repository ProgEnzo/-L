using UnityEngine;

public class Weapon3Laser : MonoBehaviour
{
    private float timer;
    private Weapon3 weapon;

    void Start()
    {
        weapon = GetComponentInParent<Weapon3>();
    }
    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Shoot();
            timer = weapon.cooldowns[weapon.tierCooldowns];
        }

        transform.localScale = new Vector3(25, weapon.sizes[weapon.tierSizes], 1);
    }

    void Shoot()
    {
        
    }
}

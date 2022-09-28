using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierDamages;

    [Header("Valeurs")]
    [SerializeField] private float[] cooldowns = new float[]{ };
    public float[] damages = new float[] { };
    public float[] angles = new float[] { };

    private float timer;
    [SerializeField] protected GameObject bullet;

    protected DirectionShoot _directionShoot;
    
    private void Start()
    {
        _directionShoot = GetComponentInParent<DirectionShoot>();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Shoot();
            timer = cooldowns[tierCooldowns];
        }
    }

    protected virtual void Shoot()
    {
        
    }
}

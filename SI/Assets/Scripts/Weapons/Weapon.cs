using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierAngles;

    [Header("Valeurs")]
    [SerializeField] protected float[] cooldowns;
    [SerializeField] protected float[] angles;

    private float timer = 1f;
    [SerializeField] protected GameObject bullet;

    protected DirectionShoot _directionShoot;
    protected Damager damager;
    
    private void Start()
    {
        _directionShoot = GetComponentInParent<DirectionShoot>();
        damager = GetComponent<Damager>();
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

    protected virtual void Shoot(){}
}

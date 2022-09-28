using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierDamages;
    public int tierAngles;

    [Header("Valeurs")]
    [SerializeField] protected float[] cooldowns;
    [SerializeField] protected float[] damages;
    [SerializeField] protected float[] angles;

    private float timer = 1f;
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

    protected virtual void Shoot(){}
}

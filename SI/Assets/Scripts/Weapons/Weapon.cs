using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region upgrades
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierAngles;
    public int tierDamages;

    [Header("Valeurs")]
    [SerializeField] protected float[] cooldowns;
    [SerializeField] protected float[] angles;
    [SerializeField] protected float[] damages;
    #endregion

    private float timer = 1f;
    [SerializeField] protected GameObject bullet;

    protected DirectionShoot _directionShoot;
    protected Damager damager;

    [Header("Level Up")]
    public int level;
    [SerializeField] protected TierEnum[] tierUpgrade;

    private void Start()
    {
        level = 0;
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
            Debug.Log(cooldowns[tierCooldowns]);
        }
    }

    public virtual void LevelUp()
    {
        switch (tierUpgrade[level])
        {
            case TierEnum.weapon:
                gameObject.SetActive(true);
                break;
            case TierEnum.damage:
                tierDamages++;
                break;
            case TierEnum.cooldown:
                tierCooldowns++;
                break;
            case TierEnum.angle:
                tierAngles++;
                break;
        }

        level++;
    }

    protected virtual void Shoot(){}
}

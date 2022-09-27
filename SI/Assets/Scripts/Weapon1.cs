using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierDamages;

    [Header("Valeurs")]
    [SerializeField] private float[] cooldowns = new float[]{ };
    public float[] damages = new float[] { };

    private float timer;
    [SerializeField] private GameObject bullet1;

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
        float angle = Mathf.Atan2(DirectionShoot.instance.direction.y - PlayerController.instance.transform.position.y, DirectionShoot.instance.direction.x - PlayerController.instance.transform.position.x) * Mathf.Rad2Deg;
        Instantiate(bullet1, transform.position, Quaternion.AngleAxis(angle, Vector3.forward), gameObject.transform);
    }
}

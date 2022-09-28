using UnityEngine;

public class Meteors : Weapon
{
    [Header("Tiers")]
    public int tierNumber;

    [Header("Valeurs")]
    [SerializeField] protected float[] numbers;

    [SerializeField] private GameObject explosionZone;

    protected override void Shoot()
    {
        for (int i = 0; i < numbers[tierNumber]; i++)
        {
            float x = Random.Range(transform.position.x - 15, transform.position.x + 15);
            float y = Random.Range(transform.position.y - 5, transform.position.y + 5);

            GameObject zone = Instantiate(explosionZone, new Vector3(x, y, 0), Quaternion.identity);
            //zone.GetComponent<ExplosionZone>().damages = damages[tierDamages];
            Destroy(zone, 0.3f);
        }
    }
}

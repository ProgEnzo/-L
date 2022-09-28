using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon4 : MonoBehaviour
{
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierDamages;
    public int tierNumber;

    [Header("Valeurs")]
    [SerializeField] public float[] cooldowns;
    [SerializeField] public float[] damages;
    [SerializeField] public float[] numbers;

    private float timer;

    public GameObject explosionZone;

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
        for (int i = 0; i < numbers[tierNumber]; i++)
        {
            float x = Random.Range(transform.position.x - 15, transform.position.x + 15);
            float y = Random.Range(transform.position.y - 5, transform.position.y + 5);
            Vector2 zone = new Vector2(x, y);

            GameObject objectToDestroy = Instantiate(explosionZone, zone, Quaternion.identity);
            Destroy(objectToDestroy, 2f);

        }
    }
}

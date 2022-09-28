using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public float tempDamage;
    [SerializeField] private GameObject explosionZone;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Wall"))
        {
            GameObject zone = Instantiate(explosionZone, transform.position, Quaternion.identity);
            zone.GetComponent<Damager>().damages = tempDamage;
            Destroy(zone, 0.3f);
                    
            Destroy(gameObject);
        }
        
    }
}

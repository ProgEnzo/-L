using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] private GameObject explosionZone;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject zone = Instantiate(explosionZone, transform.position, Quaternion.identity);
            Destroy(zone, 1f);
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject zone = Instantiate(explosionZone, transform.position, Quaternion.identity);
            //zone.GetComponent<
            Destroy(zone, 1f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Vector2 direction;
    public float damages;
    public GameObject explosionZone;
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject zone = Instantiate(explosionZone, transform.position, Quaternion.identity);
            zone.GetComponent<ExplosionZone>().damages = damages;
            Destroy(zone, 0.3f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Vector2 direction;
    public float damages;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(damages);
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("0");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Damages
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

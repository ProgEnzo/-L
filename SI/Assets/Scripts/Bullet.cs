using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;
    public float damages;

    void Start()
    {
        direction = DirectionShoot.instance.direction.normalized;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(damages);
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

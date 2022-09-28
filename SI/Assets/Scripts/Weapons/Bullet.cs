using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    public Vector2 direction;
    public float damages;

    void Start()
    {
        if(direction == null) direction = new Vector2(0,0);
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

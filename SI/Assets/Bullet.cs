using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Attack attack;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    void Start()
    {
        direction = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>().direction;
    }
    void Update()
    {
        rb.velocity = new Vector2(direction.x, direction.y) * speed;
    }
    
}

using System;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemies : MonoBehaviour
{
    private float speed;
    public float life;
    public float damages;

    public float difficultyMultiplier = 15f;
    public float xp = 10f;

    private float[] a_speed = new []{3f, 5f, 7f};
    private float[] a_life = new []{70f, 50f, 30f};
    private float[] a_damages = new [] {20f, 30f, 40f};
    private float[] a_size = new[] { 2.3f, 1.75f, 1f };

    [SerializeField] private Animator animator;

    void Start()
    {
        int x = Random.Range(0, a_speed.Length);
        speed = a_speed[x];
        damages = a_damages[x];
        life = a_life[x] * difficultyMultiplier;
        
        transform.localScale = Vector3.one * a_size[x];

        gameObject.GetComponent<AIPath>().maxSpeed = speed;
    }

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (rb.velocity.y > 0)
        {
            animator.SetBool("isGoingUp", true);
        }
        else
        {
            animator.SetBool("isGoingUp", false);
        }

        if (rb.velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }

    public void TakingDamages(float t_damages)
    {
        Debug.Log(0);
        life -= t_damages;
        if (life <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        XpManager.instance.GainXP(xp);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(damages);
        }
    }
}

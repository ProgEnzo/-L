using System.Collections;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class Enemies : MonoBehaviour
{
    private float speed;
    public float life;
    public float damages;

    public Material flash, normal;

    public float difficultyMultiplier = 1f;
    public float xp;

    [SerializeField] private timer _timer;
    
    private float[] a_speed = {3f, 5f, 7f};
    private float[] a_life = {12.5f, 9f, 5f};
    private float[] a_damages = {15f, 10f, 5f};
    private float[] a_size = { 2.3f, 1.75f, 1f };
    private float[] a_xp = { 15f, 10f, 10f };
    
    [SerializeField] private Animator animator;
    private GameObject player;

    [SerializeField] private float dropRate;
    [SerializeField] private GameObject healingHeart;

    private void Start()
    {
        _timer = FindObjectOfType<timer>();
        float currentTime = _timer.currentTime;
        difficultyMultiplier += currentTime*1.2f / 100;

        int x = Random.Range(0, a_speed.Length);
        speed = a_speed[x];
        damages = a_damages[x];
        xp = a_xp[x];
        life = a_life[x] * difficultyMultiplier;
        
        transform.localScale = Vector3.one * a_size[x];

        gameObject.GetComponent<AIPath>().maxSpeed = speed;

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Debug.Log(difficultyMultiplier);

        if (player.transform.position.y > transform.position.y)
        {
            animator.SetBool("isGoingUp", true);
        }
        else
        {
            animator.SetBool("isGoingUp", false);
        }

        if (player.transform.position.x < transform.position.x)
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

        GetComponent<SpriteRenderer>().material = flash;
        Invoke("ResetFlash", 0.15f);
        
        if (life <= 0)
        {
            Death();
        }
    }

    void ResetFlash()
    {
        GetComponent<SpriteRenderer>().material = normal;

    }
    public void Death()
    {
        XpManager.instance.GainXP(xp);
        DropLife();
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(damages);
        }
    }

    private void DropLife()
    {
        if (Random.Range(0f, 1f) <= dropRate)
        {
            Instantiate(healingHeart, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}

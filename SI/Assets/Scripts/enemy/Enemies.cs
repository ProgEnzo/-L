using Pathfinding;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float speed;
    public float life;
    public float damages;

    public float difficultyMultiplier = 15f;
    public float xp;

    private float[] a_speed = new []{3f, 5f, 7f};
    private float[] a_life = new []{70f, 50f, 30f};
    private float[] a_damages = new [] {20f, 30f, 40f};

    void Start()
    {
        int x = Random.Range(0, a_speed.Length);
        speed = a_speed[x];
        damages = a_damages[x];
        life = a_life[x] * difficultyMultiplier;

        gameObject.GetComponent<AIPath>().maxSpeed = speed;
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
        Debug.Log("Ennemi mort");
        //XpManager.instance.GainXP(xp);
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

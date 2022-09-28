using Pathfinding;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float speed;
    public float life;

    public float difficultyMultiplier = 15f;

    private float[] a_speed = new []{3f, 5f, 7f};
    private float[] a_life = new []{30f, 50f, 70f};

    void Start()
    {
        int x = Random.Range(0, a_speed.Length);
        speed = a_speed[x];
        life = a_life[^x] * difficultyMultiplier;
        Debug.Log(life);

        gameObject.GetComponent<AIPath>().maxSpeed = speed;
    }

    public void TakingDamages(float t_damages)
    {
        life -= t_damages;
        if (life <= 0)
        {
            Debug.Log("Ennemi mort");
            Destroy(gameObject);
        }
    }
}

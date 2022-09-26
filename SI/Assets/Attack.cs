using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private int timer;

    public ShootAttack shootAttack;

    void Start()
    {
        timer = 0;
        Invoke("Timer", 1f);
    }
    
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(transform.position, direction, Color.green);
    }

    void Timer()
    {
        if (timer < 60)
        {
            timer += 1;
            shootAttack.timer += 1;
        }
        else
        {
            timer = 0;
            shootAttack.timer += 1;
        }
        Invoke("Timer", 1f);
    }
}

using System;
using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float timer;

    [SerializeField] private float decrementation;

    public ShootAttack shootAttack;

    public static Attack instance;

    void Start()
    {
        timer = 0;
        Invoke("Timer", decrementation);
    }

    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        }
    }

    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        Debug.DrawRay(transform.position, direction.normalized * 10f, Color.green);
    }

    void Timer()
    {
        if (timer < 60)
        {
            timer += decrementation;
            shootAttack.timer += decrementation;
        }
        else
        {
            timer = 0;
            shootAttack.timer += decrementation;
        }
        Invoke("Timer", decrementation);
    }
}

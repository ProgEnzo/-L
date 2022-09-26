using System;
using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float timer;
    public float seconds;
    
    void Start()
    {
        timer = 0;
    }
    
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Debug.DrawRay(transform.position, direction.normalized * 10f, Color.green);
    }
}

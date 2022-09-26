using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public SO_Controller SO_Controller;

    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private float m_timerDash = 0f;
    
    private void Awake()
    {
        instance = this;
        m_rigidbody = GetComponent<Rigidbody2D>();
        
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        }
    }

    public void ResetVelocity()
    {
        m_rigidbody.velocity = Vector2.zero;
    }

    private void Start()
    {
        ReInit();
    }
    
    public void ReInit()
    {
        transform.position = Vector3.zero;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_timerDash < -0.5f)
        {
            m_timerDash = SO_Controller.m_durationDash;
        }
        
        m_timerDash -= Time.deltaTime;

    }

    public void FixedUpdate()
    {
        m_rigidbody.drag = SO_Controller.dragDeceleration * SO_Controller.dragMultiplier;
        ManageMove();
    }

    private void ManageMove()
    {
        var speed = m_timerDash <= 0 ? SO_Controller.m_speed : SO_Controller.m_dashSpeed;

        int nbInputs = (Input.GetKey(KeyCode.Z) ? 1 : 0) + (Input.GetKey(KeyCode.Q) ? 1 : 0) +
                       (Input.GetKey(KeyCode.S) ? 1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        if (nbInputs > 1) speed *= 0.75f;

        if (Input.GetKey(KeyCode.Z))
        {
            m_rigidbody.AddForce(Vector2.up*speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            m_rigidbody.AddForce(Vector2.left*speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.AddForce(Vector2.down*speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_rigidbody.AddForce(Vector2.right*speed);
        }
    }
}

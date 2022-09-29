using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    
    #region Variables Locales Controller
    
    public static PlayerController instance;
    public SO_Controller SO_Controller;

    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private float m_timerDash = 0f;
    
    [Header("Life")]
    public healthBar healthBar;

    [Header("Flags")] 
    public List<GameObject> Flammes;

    public GameObject flag;

    #endregion
    
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
        SO_Controller.currentLife = 100f;
        SO_Controller.tiers = 0;
        SO_Controller.GetFlag = false;
        SO_Controller.nombreDeFlammes = 0;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            IncrementFlammes();
        }

        if (Input.GetKey(KeyCode.E))
        {
            TakeDamage();
            
            Debug.Log("le joueur prend des dégats");
        }

    }

    public void FixedUpdate()
    {
        m_rigidbody.drag = SO_Controller.dragDeceleration * SO_Controller.dragMultiplier;
        ManageMove();
    }

    public void IncrementFlammes()
    {
        SO_Controller.nombreDeFlammes++;

        var x = FindObjectOfType<EnnemySpawnerManager>();
        
        x.EnablingSpawners();
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

    private void TakeDamage()
    {
        SO_Controller.currentLife -= Mathf.Min(Random.value, SO_Controller.currentLife / 4f);
        healthBar.UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SO_Controller.GetFlag == true && other.CompareTag("Home"))
        {
            SO_Controller.tiers += 1;
            FindObjectOfType<FlagsSpawnerManager>().SpawnFlag();
            SO_Controller.GetFlag = false;
            
            FindObjectOfType<hellFireBar>().FlagIsCaptured();

            if(flag)
                Destroy(flag);
        }
    }

    public void GetFlag()
    {
        SO_Controller.GetFlag = true;
    }
}

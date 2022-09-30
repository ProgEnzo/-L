using System;
using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    [SerializeField] private float health;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().RestoreHealth(health);
            Destroy(gameObject);
        }
    }
}

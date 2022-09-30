using System;
using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    [SerializeField] private float health;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().RestoreHealth(health);
            Destroy(gameObject);
        }
    }
}

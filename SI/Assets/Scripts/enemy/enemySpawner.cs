using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Pathfinding;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform player;

    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

    public int ID;

    private void OnEnable()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 3.5f);
    }

    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0, 4);
        
        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-3f, -2f);
                randomYposition = Random.Range(-2f, -2f);
                break;
            case 1:
                randomXposition = Random.Range(-3f, -2f);
                randomYposition = Random.Range(-2f, 2f);
                break;
            case 2:
                randomXposition = Random.Range(2f, 3f);
                randomYposition = Random.Range(-2f, -2f);
                break;
            case 3:
                randomXposition = Random.Range(-2f, 2f);
                randomYposition = Random.Range(2f, 2f);
                break;
        }

        spawnPosition = new Vector3(transform.position.x + randomXposition, transform.position.y + randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, quaternion.identity);
        newEnemy.GetComponent<AIDestinationSetter>().target = player;
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnNewEnemy");
    }

    private void OnValidate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

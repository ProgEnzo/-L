using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class FlagsSpawnerManager : MonoBehaviour
{
    private List<GameObject> flagSpawnPoint;
    
    private int rand;

    public GameObject flag;

    private void Start()
    {
        SpawnFlag();
    }

    public void SpawnFlag()
    {
        flagSpawnPoint = GameObject.FindGameObjectsWithTag("flagSpawnPoint").ToList();
        
        rand = Random.Range(0, flagSpawnPoint.Count);
        Instantiate(flag, flagSpawnPoint[rand].transform.position, quaternion.identity);
        Debug.Log(rand);
    }
}

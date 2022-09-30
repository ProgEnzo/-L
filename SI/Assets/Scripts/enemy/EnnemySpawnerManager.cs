using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawnerManager : MonoBehaviour
{
    private enemySpawner[] spawners;
    public List<int> nbrFlammesPallier; //Spawner a activer à chaque palier
    private void Awake()
    {
        spawners = FindObjectsOfType<enemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var i = 0;
        
        foreach (enemySpawner x in spawners)
        {
            x.ID = i;
            i++;
        }
        
        EnablingSpawners();
    }

    public void EnablingSpawners()
    {
        for (int i = 0; i < nbrFlammesPallier[SO_Controller.nombreDeFlammes]; i++)
        {
            foreach (enemySpawner x in spawners)
            {
                x.gameObject.SetActive(x.ID<=i);
            }
        }
    }
}

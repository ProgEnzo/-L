using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    private PlayerController player;

    public SO_Controller SoController;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (timeBtwSpawns <= 0)
            {
                Instantiate(echo, transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}

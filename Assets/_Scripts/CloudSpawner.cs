using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    [SerializeField] int spawnRate;


    private void Start() {
        InvokeRepeating("SpawnClouds", 5f, spawnRate);
    }

    void SpawnClouds() {
        Vector3 randpos = new Vector3(transform.position.x, transform.position.y + Random.Range(-3, 10), transform.position.z);
        Instantiate(cloud, randpos, Quaternion.identity);
    }
}
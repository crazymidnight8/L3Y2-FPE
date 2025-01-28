using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject enemyToSpawn;
    public GameObject bossToSpawn;

    public float spawnRate;

    public float enemiesLeft;
    public float enemiesToSpawn;

    public int waveCounter;

    // public bool canSpawn;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = enemiesToSpawn;
        timer = spawnRate;
        waveCounter = 1;

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        // canSpawn = false;
        // InvokeRepeating("Spawn", 0.5f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

        // if (canSpawn == false)
        // {
        //     Spawn();
        //     {

        //     }
        // }

        if (enemiesLeft > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Spawn();
                timer = spawnRate;
                enemiesLeft--;
            }
        } 
    }

    void Spawn()
    {
        if (waveCounter < 7)
        {
            Instantiate(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }

        if (waveCounter == 7)
        {
            Instantiate(bossToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
    }
}

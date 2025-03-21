using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{

    // Define a struct to store time and string data
    private struct SpawnData
    {
        public float time; // Time to execute the action
        public string enemyType; // Enemy type or some string data

        public SpawnData(float time, string enemyType)
        {
            this.time = Time.time + time;
            this.enemyType = enemyType;
        }
    }


    
    public GameObject enemy1;


    private List<SpawnData> spawnQueue = new List<SpawnData>();



    void Start()
    {
        spawnQueue.Add(new SpawnData(4f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(8f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(12f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(20f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(23f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(25f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(28f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(28f, "Enemy 1"));

    }

    void Update()
    {
        // Check if any items should be triggered
        for (int i = spawnQueue.Count - 1; i >= 0; i--)
        {
            if (Time.time >= spawnQueue[i].time)
            {
                SpawnEnemy(spawnQueue[i].enemyType);
                spawnQueue.RemoveAt(i); // Remove from the list
            }
        }
    }

    void SpawnEnemy(string enemyType)
    {
        Debug.Log("Spawning: " + enemyType);
        if (enemyType == "Enemy 1")
            Instantiate(enemy1);
        // if (enemyType == "Enemy 2")
            // Instantiate(enemy2);
            
    }
}
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
        spawnQueue.Add(new SpawnData(9f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(13f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(18f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(24f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(31f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(39f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(47f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(54f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(60f, "Enemy 1")); // 1 enemy per 6s until now

        // Increase spawn rate
        spawnQueue.Add(new SpawnData(66f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(71f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(75f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(78f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(81f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(84f, "Enemy 1")); // 1 enemy per ~3s now

        // Final push - high spawn rate in the last 30s
        spawnQueue.Add(new SpawnData(87f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(90f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(92f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(94f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(96f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(98f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(100f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(102f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(104f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(106f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(108f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(110f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(112f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(114f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(116f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(118f, "Enemy 1"));
        spawnQueue.Add(new SpawnData(120f, "Enemy 1")); // 1 enemy every ~2s in the last 30s

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
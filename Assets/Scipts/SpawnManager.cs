using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    private float xSpawnRange = 28;
    private float startDelay = 2;
    public float repeatRate = 1;
    private Collisions collisionsScript;
    // Start is called before the first frame update
    void Start()
    {
        
        collisionsScript = GameObject.Find("Player").GetComponent<Collisions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomFood()
    {
        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 28, 19);

        if (collisionsScript.gameOver == false)
        {
            Instantiate(foodPrefabs[foodIndex], spawnPos, foodPrefabs[foodIndex].transform.rotation);
        }
        
    }

    public void StartSpawningFood()
    {
        InvokeRepeating("SpawnRandomFood", startDelay, repeatRate);
    }
}

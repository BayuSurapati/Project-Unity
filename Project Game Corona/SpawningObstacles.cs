using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObstacles : MonoBehaviour
{

    public GameObject Obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;


    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(Obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}

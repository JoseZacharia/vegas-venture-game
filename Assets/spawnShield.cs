using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnShield : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn, minTimeBetweenSpawn, maxTimeBetweenSpawn;
    private float spawnTime;

    float timeElapsed;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        timeElapsed += Time.deltaTime;
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }

 
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(shieldPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}

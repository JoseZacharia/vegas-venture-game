using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles4 : MonoBehaviour
{    public GameObject obstacle;
    public Sprite[] obstacleSprites;
     public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float minScale, maxScale;
    private float spawnTime;


    float readyForNextDifficultyIncrease, difficultyIncreaseInterval, spawnRate;
    float a;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        spawnRate = 1 / timeBetweenSpawn;
    }
    void Update()
    {
        if (Time.time > readyForNextDifficultyIncrease)
        {
            readyForNextDifficultyIncrease = Time.time + difficultyIncreaseInterval;
            spawnRate += 0.0003f;
            //print(spawnRate);
        }

        if (Time.time > spawnTime)
        {
            if (Time.time > spawnTime)
            {
                Spawn();
                spawnTime = Time.time + 1 / spawnRate;
            }
        }
    }


    void Spawn()
    {
        float randomX = Random.Range(minX , maxX);
        float randomY = Random.Range(minY , maxY);
        GameObject obstacleInstance = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0),transform.rotation);
        a = Random.Range(minScale, maxScale);
        obstacleInstance.transform.localScale = new Vector3(a, a);
        obstacleInstance.GetComponent<SpriteRenderer>().sprite = obstacleSprites[Random.Range(0, obstacleSprites.Length - 1)];
    }
}

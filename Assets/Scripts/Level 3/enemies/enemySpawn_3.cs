using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemySpawn_3 : MonoBehaviour
{
    public GameObject obstacle;
    public Transform left, right, top, bottom;
    // public float startingSpawnRate; //spawnRateIncreaseInterval;
    //public Transform spawnPoint;

    public float spawnInterval, difficultyIncreaseInterval;
    public int maxNoOfEnemies, totalEnemies, enemiesSpawned;
    public static int currentNoOfEnemies;
    public GameObject bossEnemy;

    public GameObject enemyLeftCounterObject;
    private TextMeshProUGUI enemyLeftCounter;




    private float spawnTime, stageLength, readyForNextDifficultyIncrease;
    private int enemiesKilled;

    float spawnRate;
    float timeElapsed;

    bool enemiesStage;


    // Start is called before the first frame update
    private void Start()
    {
        spawnRate = 1 / spawnInterval;
        currentNoOfEnemies = 0;
        enemiesKilled = 0;
        enemiesSpawned = 0;
        enemiesStage = true;
        //stageLength = spawnRateIncreaseInterval;
        enemyLeftCounter = enemyLeftCounterObject.transform.Find("Enemy Left Counter").GetComponent<TextMeshProUGUI>();
        updateenemyLeftCounter();
    }
    // Update is called once per frame
    void Update()
    {

        timeElapsed += Time.deltaTime;

        if (enemiesStage == true)
        {
            if (enemiesSpawned >= totalEnemies)
            {
                spawnRate = 0;

            }

            if (enemiesKilled >= totalEnemies)
            {
                enemyLeftCounterObject.SetActive(false);
                enemiesStage = false;
                FindObjectOfType<AudioManager_3>().StopPlaying("Main theme");
                FindObjectOfType<AudioManager_3>().Play("Boss arrival");
                bossEnemy.SetActive(true);
            }
            if (Time.time > readyForNextDifficultyIncrease)
            {
                readyForNextDifficultyIncrease = Time.time + difficultyIncreaseInterval;
                spawnRate += 0.5f;
                //print(spawnRate);
            }

            if (Time.time > spawnTime)
            {
                if (currentNoOfEnemies < maxNoOfEnemies)
                {
                    Spawn();
                    spawnTime = Time.time + 1 / spawnRate;
                    currentNoOfEnemies++;
                }

            }
        }




    }
    void Spawn()
    {
        float randomX = Random.Range(left.position.x, right.position.x);
        float randomY = Random.Range(bottom.position.y, top.position.y);
        Instantiate(obstacle, new Vector3(randomX, randomY, 0), transform.rotation);
        enemiesSpawned++;
    }

    public void reduceEnemies()
    {
        currentNoOfEnemies--;
        enemiesKilled++;
        updateenemyLeftCounter();
        //print(currentNoOfEnemies);
    }

    public void updateenemyLeftCounter()
    {
        enemyLeftCounter.text = (totalEnemies - enemiesKilled).ToString();
    }

 
}

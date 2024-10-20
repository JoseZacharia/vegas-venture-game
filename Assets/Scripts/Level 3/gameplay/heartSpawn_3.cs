using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartSpawn_3 : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform left, right, top, bottom;
    public float spawnInterval;


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Spawn", 0, spawnInterval);

    }
    // Update is called once per frame
    void Update()
    {
            
        //if (Time.time > spawnTime)
        //{
        //        Spawn();
        //        spawnTime = Time.time + spawnInterval;
        //}
        
    }
    void Spawn()
    {
       // print("spawn heart");
        float randomX = Random.Range(left.position.x, right.position.x);
        float randomY = Random.Range(bottom.position.y, top.position.y);
        Instantiate(heartPrefab, new Vector3(randomX, randomY, 0), transform.rotation);

    }

}

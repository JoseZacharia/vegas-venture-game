using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife_3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float topLimit;

    void Start()
    {
        //;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (GetComponent<enemyMovement_3>().stationed && collision.gameObject.tag == "Bullet")
        { 
            GameObject.Find("Spawn Manager").GetComponent<enemySpawn_3>().reduceEnemies();
            Destroy(gameObject);
        }
            
    }
}

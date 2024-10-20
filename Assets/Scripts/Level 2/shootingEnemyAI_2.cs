using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemyAI_2: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float playerDetectDistance, retreatDistance, fireRate, movtSpeed;

    private Rigidbody2D rb;
    private Transform player;
    private bool shooting, faceLeft;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;                                          //set player as the transform assigned to script
        faceLeft = false;                                                                                       //initialize player to face left
        rb = GetComponent<Rigidbody2D>();                                                                       //set rb as rigidbody component

    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x < transform.position.x && faceLeft == false)                                       //if player is to the left of enemy 
        {
            transform.Rotate(0, 180, 0);                                                                        //rotate enemy left
            faceLeft = true;
        }
            
        else if (player.position.x >= transform.position.x && faceLeft == true)                                 //if player is to the right of enemy 
        {
            transform.Rotate(0, 180, 0);                                                                        //rotate enemy right
            faceLeft = false;
        }

        if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) < playerDetectDistance)            //if player is inside detection range
        {
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), (movtSpeed / 10) * Time.fixedDeltaTime); 
            if (shooting == false)                                                                              //if shooting = false
            {
                
                shooting = true;                                                                                //set shooting = true
                InvokeRepeating("Shoot", 0f, 1 / fireRate);                                                     //invoke shoot function repeatedly at specified firerate
            }
        }

        else if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) > playerDetectDistance)       //if player is outside detection range
        {
            shooting = false;                                                                                   //set shooting = false
            CancelInvoke();                                                                                     //stop the invoked function 
        }


        if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) < retreatDistance)                 //if player is inside retreat distance 
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), -(movtSpeed / 10) * Time.fixedDeltaTime); //enemy moves away

        }
        else if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) > retreatDistance)            //if player is outside retreat distance
        {
            rb.velocity = new Vector2(0, 0);                                                                    //enemy stops moving
        }
    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("enemy shot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);                                      //instantiate bullet prefab
    }
}

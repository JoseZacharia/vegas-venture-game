using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemyAI_2 : MonoBehaviour
{
    // Start is called before the first frame update

    public float attackSpeed;
    public float playerDetectDistance;
    private Transform player;
    private bool faceLeft;
    private Rigidbody2D rb;
    public Transform groundLimit;
    public GameObject player1;
    public Animator melee_enemy_anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;                                        //set player as the transform assigned to script
        faceLeft = true;                                                                                      //initialize player to face left
        rb = GetComponent<Rigidbody2D>();                                                                     //set rb as rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        //print(Mathf.Abs(Vector2.Distance(transform.position, player.position)));
        if(player.position.x < transform.position.x && faceLeft == false)                                     //if player is to the left of enemy 
        {
            transform.Rotate(0, 180, 0);                                                                      //rotate enemy left
            faceLeft = true;
        }
            
        else if (player.position.x >= transform.position.x && faceLeft == true)                               //if player is to the right of enemy 
        {
            transform.Rotate(0, 180, 0);                                                                      //rotate enemy right
            faceLeft = false;
        }

        if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) < playerDetectDistance)            //if player is inside detection range
        {
            // mustPatrol = false;
            melee_enemy_anim.SetBool("detects", true);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), (attackSpeed / 10) * Time.fixedDeltaTime);   //enemy moves towards player
        }

        else if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) > playerDetectDistance /*&& transform.position.y > platformLimit.position.y*/)  //if player is outside detection range
        {
            melee_enemy_anim.SetBool("detects",false);
            rb.velocity = new Vector2(0, rb.velocity.y);                                                                                                          //stop moving
        }
        if (transform.position.y < groundLimit.position.y)                                                      //if enemy postion <= ground limit
            Destroy(gameObject);                                                                                //destroy enemy gameobject
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                                                             //if enemy collides with player
            player.GetComponent<playerLoseLife_2>().loseLife();                                               //call loseLife() function
    }


}



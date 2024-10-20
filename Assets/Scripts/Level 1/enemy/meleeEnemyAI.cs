using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    public float attackSpeed;
    public float playerDetectDistance;
    public Transform groundLimit;
    public float maxHealth;
    public Animator enemyAnimator;
    healthbarBehaviour_1 healthBar;

    private float currentHealth;
    private Transform player;
    private bool faceLeft;
    private Rigidbody2D rb;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar = gameObject.GetComponentInChildren<healthbarBehaviour_1>();
        healthBar.setHealth(currentHealth, maxHealth);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        faceLeft = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(Mathf.Abs(Vector2.Distance(transform.position, player.position)));
        if (player.position.x < transform.position.x && faceLeft == false)
        {
            transform.Rotate(0, 180, 0);
            faceLeft = true;
        }
            
        else if (player.position.x >= transform.position.x && faceLeft == true)
        {
            transform.Rotate(0, 180, 0);
            faceLeft = false;
        }

        if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) < playerDetectDistance)
        {
            // mustPatrol = false;
            enemyAnimator.SetBool("playerDetected", true);
            //FindObjectOfType<AudioManager_1>().Play("melee enemy");
            GetComponent<AudioSource>().enabled = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), (attackSpeed / 10) * Time.fixedDeltaTime);
        }

        else if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) > playerDetectDistance)
        {
            enemyAnimator.SetBool("playerDetected", false);
            GetComponent<AudioSource>().enabled = false;
            //FindObjectOfType<AudioManager_1>().StopPlaying("melee enemy");
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
            
        else if (transform.position.y < groundLimit.position.y)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth--;
            healthBar.setHealth(currentHealth, maxHealth);
            if (currentHealth <= 0)
                Destroy(gameObject);
        }
            

    }


}



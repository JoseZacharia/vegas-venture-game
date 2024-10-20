using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolAI_1 : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector] public bool mustPatrol;
    private bool mustTurn;
    private Rigidbody2D rb;
    public float walkSpeed, attackSpeed;
    public Transform groundCheck;
    public LayerMask groundLayer;
    //public float playerDetectDistance;

    //private Transform player, startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mustPatrol = true;
       // player = GameObject.FindGameObjectWithTag("Player").transform;
       // startPos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
            Patrol();
        //if (Vector2.Distance(transform.position, player.position) < playerDetectDistance)
        //{
        //   // mustPatrol = false;
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, attackSpeed * Time.fixedDeltaTime);
        //}

        //else if (Vector2.Distance(transform.position, player.position) > playerDetectDistance)
        //    mustPatrol = true;
        //transform.position = Vector2.MoveTowards(transform.position, startPos.position, walkSpeed * Time.deltaTime);
        //transform.position = this.transform.position;

    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Destroy(gameObject);
    }
}

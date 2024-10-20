using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformControl_1 : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;


    private int i;
    private GameObject player;
    //private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        //playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
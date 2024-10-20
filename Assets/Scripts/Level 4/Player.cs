using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    public float sloMoTime, shieldTime;

    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.layer = 8;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //float directionY = Input.GetAxisRaw("Vertical");
        //playerDirection = new Vector2(0, directionY).normalized;

        verticalInput = Input.GetAxis("Vertical");
        if (Time.timeScale!=0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(sloMoEffect());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, verticalInput * playerSpeed);
        //rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
        FindObjectOfType<AudioManager_4>().Play("Spaceship cruising");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.tag == "Slo Mo")
            {
                Destroy(collision.gameObject);
                StartCoroutine(sloMoEffect());

            }

            if (collision.tag == "Shield")
            {
                FindObjectOfType<AudioManager_4>().Play("Shield");
                Destroy(collision.gameObject);
                StartCoroutine(shieldEffect());
            }
        
        
    }
    
    IEnumerator sloMoEffect()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(sloMoTime);
        Time.timeScale = 1;
    }

    IEnumerator shieldEffect()
    {
        gameObject.layer = LayerMask.NameToLayer("Invincibility");
        GetComponent<SpriteRenderer>().color = new Color(0.53f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(shieldTime);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(1);
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab, ammoPrefab;
    public Transform firePoint;
    public float playerDetectDistance, retreatDistance, fireRate, movtSpeed;
    public float maxHealth;
    public AudioSource weapon;
    public AudioClip shot;
    public bool flyingEnemy;

    private float currentHealth;
    private healthbarBehaviour_1 healthBar;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 startPos;
    private bool shooting, faceLeft;

    void Start()
    {
        startPos = transform.position;
        currentHealth = maxHealth;
        healthBar = gameObject.GetComponentInChildren<healthbarBehaviour_1>();
        healthBar.setHealth(currentHealth, maxHealth);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        faceLeft = false;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x < transform.position.x && faceLeft == false)
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
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), (movtSpeed / 10) * Time.fixedDeltaTime); 

            if (shooting == false)
            {
                shooting = true;
                InvokeRepeating("Shoot", 0f, 1 / fireRate);
            }

        }

        else if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) > playerDetectDistance)
        {
            shooting = false;
            CancelInvoke();
        }


        if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), -(movtSpeed / 10) * Time.fixedDeltaTime); 

        }
        else if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) > retreatDistance)
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = Vector2.MoveTowards(transform.position, startPos, (movtSpeed / 10) * Time.fixedDeltaTime);
        }
    }

    void Shoot()
    {
        weapon.PlayOneShot(shot);
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       // Physics2D.IgnoreCollision2D(GetComponent<Collider>(), bulletInstance.GetComponent<Collider>());

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth--;
            healthBar.setHealth(currentHealth, maxHealth);
            if (currentHealth <= 0)
            {
                if(flyingEnemy==false)
                    Instantiate(ammoPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
                
        }
    }
}

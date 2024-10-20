using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingTrap_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float playerDetectDistance, fireRate;
    public AudioSource weapon;
    public AudioClip shot;

    private Transform player;
    private bool shooting;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

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

    }

    void Shoot()
    {
        weapon.PlayOneShot(shot);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

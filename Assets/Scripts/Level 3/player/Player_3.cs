using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform leftLimit, rightLimit;
    [SerializeField] float speed;
    [SerializeField] GameObject bulletPrefab;
    //[SerializeField] Transform firePoint;

    Vector3 pos;
    void Start()
    {
        //FindObjectOfType<AudioManager_3>().Play("Player shooting");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}

        //to limit player boundary
        pos = transform.position;
        pos.x= Mathf.Clamp(pos.x, leftLimit.position.x, rightLimit.position.x);

        transform.position = pos;
    }

    //void Shoot()
    //{
    //    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //}
}

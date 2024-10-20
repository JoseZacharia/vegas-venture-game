using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon_3 : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	public float fireRate;
	public float bulletSpeed;

	Vector2 direction;

	//private bool shooting;
	private float readyForNextShot;

	private void Start()
	{
		//shooting = false;
	}
	// Update is called once per frame
	void Update()
	{

		if (Time.time > readyForNextShot)
		{
			readyForNextShot = Time.time + 1 / fireRate;
			Shoot();
		}

	}


	void Shoot()
	{
		FindObjectOfType<AudioManager_3>().Play("Player shooting");
		GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.up * (bulletSpeed * 10));


	}


}
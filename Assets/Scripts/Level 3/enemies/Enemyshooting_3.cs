using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshooting_3 : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	[SerializeField] float fireRate;
	float readyForNextShot;

	private float elapsed;
	private bool stationed;


	// Update is called once per frame

	private void Start()
	{
		stationed = GetComponent<enemyMovement_3>().stationed;
	}
	void Update()
	{
		//elapsed += Time.deltaTime;
		//if (elapsed >= fireRate)
		//{
		//	elapsed = elapsed % fireRate;
		//	print(Time.time);
		//	Shoot();
		//}
		stationed = GetComponent<enemyMovement_3>().stationed;
		if (stationed == true)
        {
			if (Time.time > readyForNextShot)
			{
				readyForNextShot = Time.time + 1 / fireRate;
				Shoot();
			}
		}


	}

	void Shoot()
	{
		FindObjectOfType<AudioManager_3>().Play("Enemy shooting");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
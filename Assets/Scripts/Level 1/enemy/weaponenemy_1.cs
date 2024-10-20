using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponenemy_1 : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	[SerializeField] float fireRate;
	private float elapsed;

    // Update is called once per frame

    private void Start()
    {
		InvokeRepeating("Shoot", 0f, 1/fireRate);
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
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting_3 : MonoBehaviour
{

	public Transform[] firePointMinor;
	public Transform firePointMain;
	public GameObject bulletMainPrefab, bulletMinorPrefab;
	float readyForNextShotMain;
	[SerializeField] float fireRateMain;
	float readyForNextShotMinor;

	float fireRateMinor;
	private float elapsed;
	private bool stationed;


	// Update is called once per frame

	private void Start()
	{
		fireRateMinor = fireRateMain / 2;
		stationed = GetComponent<bossMovement_3>().stationed;

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
		stationed = GetComponent<bossMovement_3>().stationed;
		if (stationed == true)
		{
			if (Time.time > readyForNextShotMain)
			{
				readyForNextShotMain = Time.time + 1 / fireRateMain;
				FindObjectOfType<AudioManager_3>().Play("Boss bullet");
				ShootMain();
			}
			if (Time.time > readyForNextShotMinor)
			{
				readyForNextShotMinor = Time.time + 1 / fireRateMinor;
				shootMinor();
			}

		}


	}

	void ShootMain()
	{

		FindObjectOfType<AudioManager_3>().Play("Boss bullet");
		Instantiate(bulletMainPrefab, firePointMain.position, firePointMain.rotation);
		
		
	}

	void shootMinor()
    {
		foreach (Transform firePoint in firePointMinor)
		{
			FindObjectOfType<AudioManager_3>().Play("Enemy shooting");
			GameObject bulletInstance = Instantiate(bulletMinorPrefab, firePoint.position, firePoint.rotation);
			//bulletInstance.GetComponent<Bullet_3>().moveSpeed /= 2f;
		}
	}
}
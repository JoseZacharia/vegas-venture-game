using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weapon_1 : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	public float fireRate;
	public float bulletSpeed;
	public float range;

	public int maxAmmo, ammoLeft;
	public int ammoReload;
	public TextMeshProUGUI ammoCounter;

	Vector2 direction;

	//private bool shooting;
	private float readyForNextShot;
	public AudioSource weapon;
	public AudioClip shot;
    private void Start()
    {
		ammoLeft = maxAmmo;
		displayAmmo();
		//shooting = false;
	}
    // Update is called once per frame
    void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = mousePos - (Vector2)transform.position;
		faceMouse();

		if (Input.GetButton("Fire1"))
		{
			if(Time.time > readyForNextShot)
            {
				readyForNextShot = Time.time + 1/fireRate;
				if(ammoLeft>0)
					Shoot();
			}
			
		}
			
	}

	void faceMouse()
	{
		transform.right = direction;
	}

	void Shoot()
	{
		weapon.PlayOneShot(shot);
		GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		//bulletInstance.GetComponent<AudioSource>().enabled = true;
		bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * (bulletSpeed * 10));
		bulletInstance.GetComponent<bullet_1>().setRange(range);
		ammoLeft--;
		displayAmmo();
	}

    public void collectAmmo()
    {
		ammoLeft += ammoReload;
		if(ammoLeft>maxAmmo)
        {
			ammoLeft = maxAmmo;
        }
		displayAmmo();
    }

	void displayAmmo()
    {
		ammoCounter.text = ammoLeft.ToString() + "/" + maxAmmo.ToString();
	}
}
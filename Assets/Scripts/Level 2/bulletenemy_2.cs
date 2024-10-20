using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletenemy_2 : MonoBehaviour
{

	public float speed = 20f;
	public int damage = 40;
	Rigidbody2D rb;
	public GameObject impactEffect;
	private float timeElapsed;
	public int bulletTimeout;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();																				//set rb as rigidbody component	
		rb.velocity = transform.right * speed;																			//set bullet velocity as speed
	}

	private void Update()
	{
		timeElapsed += Time.deltaTime;																					//start counting the time that has passed and assign to timeElapsed
		if (timeElapsed > bulletTimeout)																				//if timeElaspsed > bulletTimeout
		{
			Destroy(gameObject);																						//destroy bullet gameobject
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag != "Trap" && collision.gameObject.tag != "Enemy")									//if bullet collides with enemy or trap
		{																												//destroy bullet gameobject
			Destroy(gameObject);
		}
			
    }

}
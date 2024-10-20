using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet_3 : MonoBehaviour
{

	public float speed = 20f;
	public int damage = 4;
	Rigidbody2D rb;
	public GameObject impactEffect;
	private float timeElapsed;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
	}

	private void Update()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed > 2)
		{
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D hitInfo)
	{
		//if(hitInfo.name!="Player" || Time.deltaTime > 2)
		//	Destroy(gameObject);

		if (hitInfo.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
			//Destroy(hitInfo.gameObject);
		}




	}

}
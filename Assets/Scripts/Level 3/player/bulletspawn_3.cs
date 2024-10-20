using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspawn_3 : MonoBehaviour
{

	public float speed = 20f;
	public int damage = 40;
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
			Destroy(gameObject);  //life of bullet
		}
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag != "Player")
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}

}
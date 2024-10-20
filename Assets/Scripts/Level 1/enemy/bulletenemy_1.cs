using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletenemy_1 : MonoBehaviour
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
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * speed;
	}

	private void Update()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed > bulletTimeout)
		{
			Destroy(gameObject);
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag != tag)
			Destroy(gameObject);
    }

}
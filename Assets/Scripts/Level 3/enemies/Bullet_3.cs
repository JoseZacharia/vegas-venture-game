using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_3 : MonoBehaviour
{

	public float moveSpeed = 7f;
	public int bulletTimeout;

	Rigidbody2D rb;

	Player_3 target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Player_3>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, bulletTimeout);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "Bullet")
			Destroy(gameObject);
	}

}


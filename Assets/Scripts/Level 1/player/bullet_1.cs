using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_1 : MonoBehaviour
{

	//public float speed = 20f;
	public float timeout = 2;
	public int damage = 40;
	Rigidbody2D rb;
	public GameObject impactEffect;
	

	public static float range;


	private Vector2 startPos;
	private float timeElapsed;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//rb.velocity = transform.right * speed;
		startPos = transform.position;
	}

	public void setRange(float newRange)
    {
		range = newRange;
    }

    private void Update()
    {
		//timeElapsed += Time.deltaTime;
		//if (timeElapsed > 2)
		//{
		//	Destroy(gameObject);
		//}

		if (Mathf.Abs(Vector2.Distance(transform.position, startPos)) > range)
			Destroy(gameObject);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag !="Player")
			Destroy(gameObject);
    }



}
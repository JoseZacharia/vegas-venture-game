using UnityEngine;
using System.Collections;

public class ArmRotationEnemy_1 : MonoBehaviour
{

	private Transform player;
	Vector2 direction;
    // Update is called once per fram

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    /* void Update()
     {
         // subtracting the position of the player from the mouse position
         Vector3 difference = player.position - transform.position;

         difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1
         //print(difference);
         float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // find the angle in degrees
         transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
     }*/

    private void Update()
    {
        direction = player.position - transform.position;
        faceMouse();

    }

    void faceMouse()
    {
        transform.right = direction;
    }
}

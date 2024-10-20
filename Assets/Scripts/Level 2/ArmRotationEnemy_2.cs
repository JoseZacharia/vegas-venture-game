using UnityEngine;
using System.Collections;

public class ArmRotationEnemy_2 : MonoBehaviour
{

	private Transform player;
    // Update is called once per fram

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;					//intializing player as the transform that is assigned to this script
	}

    void Update()
	{
																						// subtracting the position of the player from the mouse position
		Vector3 difference = player.position - transform.position;

		difference.Normalize();															// normalizing the vector. Meaning that all the sum of the vector will be equal to 1
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;			// find the angle in degrees
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);							//rotate the arm of the enemy to where the player is
	}
}

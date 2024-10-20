using UnityEngine;
using System.Collections;

public class ArmRotation_1 : MonoBehaviour {

	Vector2 direction;

    private void Update()
    {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = mousePos - (Vector2)transform.position;
		faceMouse();

    }

	void faceMouse()
    {
		transform.right = direction;
    }
}

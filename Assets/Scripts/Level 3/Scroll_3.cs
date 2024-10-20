 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_3 : MonoBehaviour
{
    public float speed = 4f;    //scrolling speed
    private Vector3 StartPosition;
    public Transform resetpoint;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position; //current position background
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3.down * speed * Time.deltaTime); //to move background downwards
        if(transform.position.y < resetpoint.position.y)  //end of bacground
        {
            transform.position = StartPosition; //reset to orginal position
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovt_2 : MonoBehaviour
{

    private Vector3 offset = new Vector3(5, 2, -10);

    private float smoothtime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    bool faceleft;
    Vector3 targetpos;

    public GameObject target;
    // Start is called before the first frame update
  

    private void Update()
    {
        faceleft = GameObject.Find("Player").GetComponent<PlayerMovt_2>().faceleft;                                 //get direction which plyer is facing towards
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        if(!faceleft)                                                                                               //if player faces right   
            targetpos = target.transform.position + offset;                                                         //camera goes to player position
        else                                                                                                        //if player faces right
            targetpos = target.transform.position + new Vector3(-offset.x,offset.y,offset.z);                       //adjust offset accordingly
        transform.position = Vector3.SmoothDamp(transform.position, targetpos, ref velocity, smoothtime);
    }
}

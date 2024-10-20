using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovt_1 : MonoBehaviour
{
    public float bottomLimit, topLimit, leftLimit, rightLimit;
    public bool editMode;
    public GameObject player;

    private float smoothtime = 0.5f;
    private Vector3 velocity = Vector3.zero, offset;
    bool faceleft;
   
    // Start is called before the first frame update
    void Start()
    {
        //to store distance between camera and player as specified in the Editor  
        if(editMode==false)
            offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        //check if player facing left
        faceleft = player.GetComponent<PlayerMovt_1>().faceleft;
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        //smooth camera following of player 
        if (!faceleft)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, -10), ref velocity, smoothtime);
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x - offset.x, player.transform.position.y + offset.y, -10), ref velocity, smoothtime);
        }

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));//top line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));//right line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));//bottom line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit)); //left line

    }
}

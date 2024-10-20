using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartBehaviour_3 : MonoBehaviour
{
    public Transform sceneBottomLimit;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager_3>().StopPlaying("Health boost");
        sceneBottomLimit = GameObject.Find("Bottom Limit").transform;
        //print(sceneBottomLimit);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (speed/100));
        if (transform.position.y < sceneBottomLimit.position.y)
            Destroy(gameObject);
    }


}

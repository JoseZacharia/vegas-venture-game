using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformRespawner_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] flPlatformSpots;
    public GameObject flPlatformPrefab;
    GameObject clone1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Falling Platform/Falling Platform Structure")==null)
        {
            Invoke("createPlatform", 1);
            
        }
    }

    void createPlatform()
    {
        print("new " + this.transform);
        //clone1 = Instantiate(flPlatformPrefab, transform.position, transform.rotation);
        //clone1.transform.parent = this.transform;
    }
}

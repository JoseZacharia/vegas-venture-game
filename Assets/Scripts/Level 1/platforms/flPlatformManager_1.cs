using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flPlatformManager_1 : MonoBehaviour
{

	public static bool isExisting;
	public static flPlatformManager_1 Instance = null;


	[SerializeField] GameObject platformPrefab;
	[SerializeField] Transform flPlatformSpot;

	void Awake()
	{
		isExisting = true;

	}
	// Use this for initialization
	void Start()
	{
		
		//Instantiate(platformPrefab, new Vector2(0f, -2.5f), platformPrefab.transform.rotation);
		//Instantiate(platformPrefab, new Vector2(3.5f, -2.5f), platformPrefab.transform.rotation);
	}


    private void FixedUpdate()
    {
        if(isExisting == false)
        {
			isExisting = true;
			Invoke("createPlatform", 3);
		}
    }

	void createPlatform()
    {
		Instantiate(platformPrefab, new Vector2(flPlatformSpot.position.x, flPlatformSpot.position.y), platformPrefab.transform.rotation);
	}

}

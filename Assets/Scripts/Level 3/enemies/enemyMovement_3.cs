using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement_3 : MonoBehaviour
{
    GameObject player, enemySpawnManager;
    Transform top, bottom;
    public float speed, stationSpeed;
    public float stationDistance;

    public bool stationed;
    Vector3 stationPoint;
    // Start is called before the first frame update
    void Start()
    {
        stationed = false;
        stationPoint = transform.position - new Vector3(0, stationDistance, 0);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(stationed == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, stationPoint, stationSpeed * Time.deltaTime);
            if (transform.position == stationPoint)
                stationed = true;
        }    
        else
            transform.position = Vector2.Lerp(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkPointReached;
    void Start()
    {
        checkPointReached = false;
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(checkPointReached == false)
            {
                FindObjectOfType<AudioManager_1>().Play("checkpoint reached");
                checkpointSpriteRenderer.color = Color.green;
                checkPointReached = true;
            }
        }
    }
}


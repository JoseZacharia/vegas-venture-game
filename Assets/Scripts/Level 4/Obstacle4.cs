using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4 : MonoBehaviour
{    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Border")
    {
        Destroy(this.gameObject);
    }
    else if(collision.tag == "Player")
    {

            if(PlayerPrefs.GetInt("invincible")==0)
            {
                FindObjectOfType<AudioManager_4>().Play("Spaceship Explosion");
                Destroy(player.gameObject);
            }
               
    }
   }
    
}

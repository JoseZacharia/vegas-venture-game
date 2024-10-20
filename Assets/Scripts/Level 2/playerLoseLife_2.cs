using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerLoseLife_2 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] static int playerLives = 1;
    public GameObject gameoverscreen;   

    private void OnCollisionEnter2D(Collision2D collision)                                                  
    {
        if (collision.gameObject.tag == "Trap")                                                                 //if player collides with Trap
            loseLife();                                                                                         //call loseLife function
    }
    public void loseLife()
    {
        //print("die");
        if(PlayerPrefs.GetInt("invincible")==0)
        {
            playerLives--;                                                                                          //decrement pleyerLIves by 1

            if (playerLives <= 0)                                                                                   //if playerlives is 0 or less
            {                                                                                                       //print("gameover");            
                Time.timeScale = 0;                                                                                 //stop gameplay 
                FindObjectOfType<AudioManager>().StopPlaying("Theme");
                FindObjectOfType<AudioManager>().Play("Game Over");
                gameoverscreen.SetActive(true);                                                                     // show game over screen                                                         
                playerLives = 1;
            }
        }
        
     
    }


}
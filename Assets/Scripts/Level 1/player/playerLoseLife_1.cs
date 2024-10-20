using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerLoseLife_1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] static int playerLives = 3;
    public int Lives;
    public GameObject gameoverscreen;
    float initx, inity;
    public TextMeshProUGUI livesCounter;
    public bool invincible;

    public Vector3 respawnPoint;

    void Start()
    {
        playerLives = Lives;
        displayLives();
        respawnPoint = transform.position;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("invincible") == 1)
            invincible = true;
        else
            invincible = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy")
           loseLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Heart")
        {
            FindObjectOfType<AudioManager_1>().Play("collected");
            playerLives++;
            displayLives();
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Checkpoint")
        {
            //FindObjectOfType<AudioManager_1>().Play("checkpoint reached");
            respawnPoint = collision.transform.position;
        }
    }


    public void loseLife()
    {
        if(invincible == false)
        {
            FindObjectOfType<AudioManager_1>().Play("death");
            playerLives--;

            if (playerLives <= 0)
            {
                //print("gameover");
                FindObjectOfType<AudioManager_1>().StopPlaying("lvl 1 theme");
                FindObjectOfType<AudioManager_1>().Play("game over");
                Time.timeScale = 0; //stop gameplay
                gameoverscreen.SetActive(true);// show game over screen
                playerLives = 3;
            }
            else if (playerLives > 0)
            {
                //print("restart");
                //SceneManager.LoadScene("Level");
                transform.position = respawnPoint;

            }
            displayLives();
        }
        //print("die");
        


    }

    public void displayLives()
    {
        livesCounter.text = playerLives.ToString();
    }

}

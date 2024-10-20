using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovt_2 : MonoBehaviour
{
    public GameObject head, gameoverscreen,winScreen;
    public bool faceleft = false;
    public Transform groundcheckTransform = null, GroundLimit,winPoint;
    public Canvas statsTracker;
    public static int currentFuel = 0;
    [SerializeField] int targetFuel;
    public TextMeshProUGUI fuelTracker;
    public float boostMultiplier;
    public float boostTimer;
    public Animator playerAnimator;

    bool jumpkeypressed;
    float horizontalinput;
    [Range(0,100)]public float jumpforce;
    [Range(0, 500)] public float speed;
    float normSpeed;
    float normJump; 
    private float boostEnd = 0.0f;
    private bool boosting = false;
    private bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        Time.timeScale = 1;                                                                             
        currentFuel = 0;                                                                            //currentFuel = 0
        normJump = jumpforce;                                                                       //set normalJump as initial jumpforce value
        normSpeed = speed;                                                                          //set normalspeed as initial speed value
        playerAnimator = GetComponent<Animator>();                                                  //Grab reference for animator from object
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");                                                      // horizontal input =-1 for left direction and 1 for right direction
        playerAnimator.SetBool("isRunning", horizontalinput!=0 );                                           //set isRunning value according to horizontal input
        playerAnimator.SetBool("isGrounded", isGrounded);
        
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))                           //if W or up arrow key is pressed
        {
            //Debug.Log("jump");
            jumpkeypressed = true;                                                                          //jumpkeypressed = true
        }

        if (horizontalinput > 0.01f && faceleft)                                                            //if right key is pressed
        {
            //transform.localScale = new Vector3(1, 1,1);
            transform.Rotate(0, 180, 0);                                                                    //rotate player to face the right
            faceleft = false;                                                                               
        }
        else if (horizontalinput < -0.01f && !faceleft)                                                     //if left key is pressed
        {
            //transform.localScale = new Vector3(-1, 1,1);
            transform.Rotate(0, 180, 0);                                                                    //rotate player to face left
            faceleft = true;
        }
                                                                                                            //loss due to falling
        if (head.transform.position.y < GroundLimit.transform.position.y)                                   //if head of player < ground limit
        {
            Time.timeScale = 0;
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            FindObjectOfType<AudioManager>().StopPlaying("low oxygen");
            FindObjectOfType<AudioManager>().Play("Falling below ground limit");
            gameoverscreen.SetActive(true);                                                                 //Display game over screen

        }
                                                                                                            //win condition
        if (head.transform.position.x >= winPoint.transform.position.x && (currentFuel >= targetFuel))      //if player is at win point && player has required target fuel 
        {

            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            FindObjectOfType<AudioManager>().StopPlaying("low oxygen");
            FindObjectOfType<AudioManager>().Play("Level won");
            
            Time.timeScale=0;
            winScreen.SetActive(true);                                                                      //show level won screen
            
        }

        fuelTracker.text = currentFuel.ToString("0") + "/" + targetFuel.ToString("0");    //display fuel percentage

        if (currentFuel >= targetFuel)                                                                          //when required number of fuel tanks are collected
        {
            fuelTracker.color = Color.green;                                                                    //Fuel is displayed in Green
        }

        if(boosting)                                                                                            //when boost is taken
        {
            boostEnd += Time.deltaTime;
            if(boostEnd >= boostTimer)                                                                          //when boost timer is over
            {
                speed = normSpeed;                                                                              //set speed and jumpforce as its initial values
                jumpforce = normJump;
                boostEnd = 0;
                boosting = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircleAll(groundcheckTransform.position, 0.45f).Length == 2)
        {
            isGrounded = true;
            
        }

        else if (Physics2D.OverlapCircleAll(groundcheckTransform.position, 0.45f).Length != 2)
        {
            isGrounded = false;
            playerAnimator.SetTrigger("jump");
        }

        if (jumpkeypressed && (Physics2D.OverlapCircleAll(groundcheckTransform.position, 0.45f).Length == 2) && boosting)               //if jump key is pressed and player is not grounded
        {
            FindObjectOfType<AudioManager>().Play("Jump with boots");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);                           //player is made to jump with velocit of jumpforce
            jumpkeypressed = false;

        }

        if (jumpkeypressed && (Physics2D.OverlapCircleAll(groundcheckTransform.position, 0.45f).Length == 2) )               //if jump key is pressed and player is not grounded
        {
            
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);                           //player is made to jump with velocit of jumpforce
                jumpkeypressed = false;
            
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalinput*speed, GetComponent<Rigidbody2D>().velocity.y);   //change horizontal velocity according to horizontal input 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "O2 Tank")                                                  //if player collides with O2 tank
        {
            FindObjectOfType<AudioManager>().Play("Picked up O2 Tank");
            statsTracker.GetComponent<Stats_2>().updateO2();                                       //call updatO2 function from Stats_2 to increase O2
            Destroy(collision.gameObject);                                                         //destroy the O2 gameobject 
        }

        if (collision.gameObject.tag == "Fuel Tank")                                               //if player collides with Fuel tank
        {
            FindObjectOfType<AudioManager>().Play("Picked up Fuel Tank");
            currentFuel++;                                                                         //increment currentFuel by one
            Destroy(collision.gameObject);                                                         //destroy the Fuel tank gameobject 
        }

        if (collision.gameObject.tag == "Speed Boost")                                             //if player collides with Boots
        {
            FindObjectOfType<AudioManager>().Play("Picked up boots");
            boosting = true;                                                                       //set boosting as true
            speed *= boostMultiplier;                                                              //speed = speed * boostMultiplier
            jumpforce *= boostMultiplier*0.85f;                                                    //jumpforce = jumpforce * boostMultiplier;
            Destroy(collision.gameObject);                                                         //destroy Boots gameobject
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")                                                    //if player collides with Shooting Enemy
        {
            statsTracker.GetComponent<Stats_2>().decrementO2();                                     //call decrement O2 from Stats_2 to decrease O2
        }
    }

    public void restartlevel()
    {
        SceneManager.LoadScene("Level 2");                                                           //load Level 2
    }
}

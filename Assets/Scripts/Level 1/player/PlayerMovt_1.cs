using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovt_1 : MonoBehaviour
{
    public GameObject head, gameoverscreen, cam, winScreen, collectKeyWarn, door;
    bool jumpkeypressed;
    float horizontalinput;
    [Range(0,100)]public int jumpforce;
    [Range(0, 500)] public int speed;
    public bool faceleft = false;
    public Transform groundlimit, groundCheck, winPoint, doorFrontPoint;
    public static bool hasKey = false;
    public GameObject pauseMenu;

    public GameObject weapon;
    public Animator playerAnimator;

    private bool isGrounded;
    //private playerLoseLife player;
    // Start is called before the first frame update
    void Start()
    {
        //normal speed gameplay
        
    }

    // Update is called once per frame
    void Update()
    {
        //get amount of horizontal input

        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Time.timeScale = 0;
        //    pauseMenu.SetActive(true);
        //}

        horizontalinput = Input.GetAxis("Horizontal");

        playerAnimator.SetBool("isRunning", horizontalinput != 0);                                           //set isRunning value according to horizontal input
        playerAnimator.SetBool("isGrounded", isGrounded);

        // get jump input
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            jumpkeypressed = true;
        }

        //to flip character right
        if (horizontalinput > 0.01f && faceleft)
        {
            transform.Rotate(0, 180, 0);
            faceleft = false;
        }
        //to flip character left
        else if (horizontalinput < -0.01f && !faceleft)
        {
            transform.Rotate(0, 180, 0);
            faceleft = true;
        }

        //to check if player has fallen below limits
        if (head.transform.position.y < groundlimit.transform.position.y)
        {
            //gameoverscreen.SetActive(true);// show game over screen
            //Time.timeScale = 0; //stop gameplay
            FindObjectOfType<AudioManager_1>().Play("fall scream");
            GetComponent<playerLoseLife_1>().loseLife();
            
        }
        if ((head.transform.position.x >= doorFrontPoint.position.x))
        {
            if (hasKey == false)
                collectKeyWarn.SetActive(true);
            else
            {
                door.GetComponent<AudioSource>().enabled = true;
                door.transform.position = Vector3.MoveTowards(door.transform.position, new Vector3(door.transform.position.x, door.transform.position.y + 10), 8 * Time.deltaTime);
            }
               

        }

        if ((head.transform.position.x >= winPoint.position.x))
        {
            FindObjectOfType<AudioManager_1>().StopPlaying("lvl 1 theme");
            winScreen.GetComponent<AudioSource>().enabled = true;
            Time.timeScale = 0;  //stop gameplay
            winScreen.SetActive(true);// show level complete screen
                                     

        }

    }

    private void FixedUpdate()
    {
        collectKeyWarn.SetActive(false);
        //implement jumping
        if (Physics2D.OverlapCircleAll(groundCheck.position, 0.25f).Length == 2)
        {
            isGrounded = true;
        }

        else if (Physics2D.OverlapCircleAll(groundCheck.position, 0.25f).Length != 2)
        {
            isGrounded = false;
            playerAnimator.SetTrigger("jump");
        }
        if (jumpkeypressed && (Physics2D.OverlapCircleAll(groundCheck.position, 0.25f).Length == 2))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
            jumpkeypressed = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalinput*speed, GetComponent<Rigidbody2D>().velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Key")
        {
            //print("key");
            FindObjectOfType<AudioManager_1>().Play("collected");
            hasKey = true;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Ammo")
        {
            //print("Ammo");
            FindObjectOfType<AudioManager_1>().Play("ammo reload");
            Destroy(collision.gameObject);
            weapon.GetComponent<weapon_1>().collectAmmo();
            
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump Platform")
        {
            jumpforce *= 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump Platform")
        {
            jumpforce /= 2;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameplayManager_3 : MonoBehaviour
{
    public GameObject tutorial;
    bool themePlaying;
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadScene("Background Operations", LoadSceneMode.Additive);
        Time.timeScale = 0;
        PlayerPrefs.SetString("Current Level", "Level 3");
        tutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            tutorial.SetActive(false);
            Time.timeScale = 1;
            if(themePlaying==false)
            {
                FindObjectOfType<AudioManager_3>().Play("Main theme");
                themePlaying = true;
            }
            

        }
    }

    public void restartLevel3()
    {
        //FindObjectOfType<AudioManager_3>().StopPlaying("Player shooting");
        FindObjectOfType<AudioManager_3>().StopPlaying("Main theme");
        //FindObjectOfType<AudioManager_3>().StopPlaying("Boss bullet");
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 3");
    }

    public void proceedToNextLevel()
    {
        SceneManager.LoadScene("Level 4");
    }
}

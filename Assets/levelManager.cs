using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseMenu;

    bool pauseMenuActive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuActive == false)
            {
                pauseMenu.SetActive(true);
                pauseMenuActive = true;
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                pauseMenuActive = false;
                Time.timeScale = 1;
            }

            
        }
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void quitLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Current Level"));
    }
}

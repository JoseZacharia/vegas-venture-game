using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorial;
    private void Awake()
    {
        SceneManager.LoadScene("Background Operations", LoadSceneMode.Additive);
        Time.timeScale = 1;
        PlayerPrefs.SetString("Current Level", "Level 1");
        tutorial.SetActive(true);

    }

    private void Start()
    {
        FindObjectOfType<AudioManager_1>().Play("lvl 1 theme");
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            tutorial.SetActive(false);
        }
    }


    public void restartLevel()
    {
        //restart level by reloading scene
        SceneManager.LoadScene("Level 1");
    }

    public void proceedToNextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void continueGame()
    {
        print(PlayerPrefs.GetString("Current Level"));
        SceneManager.LoadScene(PlayerPrefs.GetString("Current Level"));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Background Operations", LoadSceneMode.Additive);
        Invoke("gotoMainMenu", 45f);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            gotoMainMenu();
        }
    }
    private void gotoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

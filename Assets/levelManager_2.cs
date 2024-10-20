using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorial, O2SliderObject;
    private void Awake()
    {
        SceneManager.LoadScene("Background Operations", LoadSceneMode.Additive);
        O2SliderObject.SetActive(false);
        PlayerPrefs.SetString("Current Level", "Level 2");
        tutorial.SetActive(true);
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            tutorial.SetActive(false);
            O2SliderObject.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void proceed()
    {
        SceneManager.LoadScene("Level 3");
    }
}

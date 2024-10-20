using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame4 : MonoBehaviour
{     
    public GameObject gameOverPanel, timerSliderObject, earth, spawnManager;
    public float maxTimeLeft;
   // [SerializeField] TextMeshProUGUI countdowntext;
    public Slider timerSlider;

    private float timeLeft;

    private void Start()
    {
        timeLeft = maxTimeLeft;
        timerSlider.maxValue = timeLeft;
        timerSlider.value = 0;
        //FindObjectOfType<AudioManager_4>().Play("Main theme");
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //countdowntext.text = ("Time Left : "+ (timeLeft).ToString("0.0"));
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Time.timeScale = 0;
            FindObjectOfType<AudioManager_4>().StopPlaying("Spaceship cruising");
            FindObjectOfType<AudioManager_4>().StopPlaying("Main theme");
            timerSliderObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }
        if (timeLeft <= 0 && GameObject.FindGameObjectWithTag("Player") != null)
        {
            FindObjectOfType<AudioManager_4>().StopPlaying("Main theme");
            timerSliderObject.SetActive(false);
            GameObject.Find("Player").layer= LayerMask.NameToLayer("Invincibility");
            spawnManager.SetActive(false);
            Invoke("spawnEarth", 3f);
            //Invoke("loadFinalCredits", 3f);
            timeLeft = 0;
        }
        updateSlider();
    }

    void updateSlider()
    {
        timerSlider.value = maxTimeLeft - timeLeft;
    }

    void loadFinalCredits()
    {
        SceneManager.LoadScene("Final Credits");

    }

    void spawnEarth()
    {
        earth.SetActive(true);
        Invoke("loadFinalCredits", 4f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats_2 : MonoBehaviour
{
    public static float currentPercentage;
    [SerializeField] float levelduration;
    [SerializeField] float increment,decrement;
    [SerializeField] TextMeshProUGUI countdownText;
    public GameObject gameoverscreen;

    public O2Slider_2 o2slider;

    private void Start()
    {
        currentPercentage = 100f;                                                                        //initialize currentPercentage as 100
        o2slider.setMax(100f);
    }
    void Update()
    {
        currentPercentage -= Time.deltaTime * (100/levelduration);                                       //decrease currentPercentage according to levelduration
        o2slider.setpercent(currentPercentage);
        countdownText.text = "O2 Level : " + currentPercentage.ToString("0.00") + "%";                   //Display the O2 level in string format

        if (currentPercentage <= 30f && currentPercentage >= 0)                                          //if currentPercentage < 30 
        {
            FindObjectOfType<AudioManager>().Play("low oxygen");
            countdownText.color = Color.red;                                                             //change color of countdownText to red

        }
        else if (currentPercentage > 30)
        {
            FindObjectOfType<AudioManager>().StopPlaying("low oxygen");
            countdownText.color = Color.white;                                                              //default color is white
        }

        else if(currentPercentage <= 0)                                                                        //when currentPercentage is 0 or less
        {
            if (PlayerPrefs.GetInt("invincible") == 0)
            {
                FindObjectOfType<AudioManager>().StopPlaying("Theme");
                FindObjectOfType<AudioManager>().StopPlaying("low oxygen");
                FindObjectOfType<AudioManager>().Play("Game Over");
                gameoverscreen.SetActive(true);                                                               //display game over screen
                Time.timeScale = 0;
                currentPercentage = 100;                                                                      //set currentPercentage as 100 again
            }
            
        }
    }

    public void updateO2()
    {
        if ((currentPercentage + increment) > 100)                                                        //if currentpercentage + increment > 100
            currentPercentage = 100;                                                                      //set currentpercentage as 100
        else
            currentPercentage += increment;                                                               //set currentPercentage = currentpercentage + increment

    }

    public void decrementO2()
    {
        currentPercentage -= decrement;                                                                   //set currentPercentage = currentpercentage - decrement
    }
}

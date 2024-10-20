using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver4 : MonoBehaviour
{  
    public GameObject gameOverPanel, timerSlider;
    //[SerializeField] TextMeshProUGUI countdowntext2;
  //  private float timeLeft2;




// Update is called once per frame
void Update()
{
    if(GameObject.FindGameObjectWithTag("Player") == null)
    {
            Time.timeScale = 0;
            timerSlider.SetActive(false);
            gameOverPanel.SetActive(true);
            
           // timeLeft2 = 0;
           // countdowntext2.text = ("Time Left : " + (timeLeft2).ToString("0.0"));

    }

    


}

}

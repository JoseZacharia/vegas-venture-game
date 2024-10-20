using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bossHealth_3 : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxBossHealth;
    public GameObject bossHealthCounterObject, winScreen;


    private int currentBossHealth;
    private TextMeshProUGUI bossHealthCounter;

    void Start()
    {
        currentBossHealth = maxBossHealth;
        StartCoroutine(activateBossHealthCounter());
        bossHealthCounter = bossHealthCounterObject.transform.Find("Boss Health Counter").GetComponent<TextMeshProUGUI>();
        updateBossHealthCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBossHealth <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            FindObjectOfType<AudioManager_3>().StopPlaying("Player shooting");
            FindObjectOfType<AudioManager_3>().StopPlaying("Main theme");
            FindObjectOfType<AudioManager_3>().StopPlaying("Boss bullet");
            FindObjectOfType<AudioManager_3>().StopPlaying("Boss arrival");
            FindObjectOfType<AudioManager_3>().Play("Level won");
            winScreen.SetActive(true);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<bossMovement_3>().stationed == true && collision.gameObject.tag == "Bullet")
        {

            currentBossHealth--;
            updateBossHealthCounter();
            //print(currentBossHealth);
        }

    }

    public void updateBossHealthCounter()
    {
        bossHealthCounter.text = currentBossHealth.ToString();
    }

    IEnumerator activateBossHealthCounter()
    {
        yield return new WaitForSeconds(2);
        bossHealthCounterObject.SetActive(true);
    }
}

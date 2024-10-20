using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storyManager : MonoBehaviour
{
    public GameObject[] storyBoardList;
    int currentSlideIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSlideIndex = 0;
        storyBoardList[currentSlideIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextSlide()
    {
        storyBoardList[currentSlideIndex].SetActive(false);
        currentSlideIndex++;
        storyBoardList[currentSlideIndex].SetActive(true);

    }

    public void proceedToGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}

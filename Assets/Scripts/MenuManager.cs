using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public GameObject startButton, tryAgainButton;
    public TextMeshProUGUI scoreTMP, bestScoreTMP;
    
    private void Awake()
    {
        instance = this;
    }
    
    public void StartGame()
    {
        GameManager.instance.OpenFirstCube();
        startButton.SetActive(false);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenTryAgainButton()
    {
        tryAgainButton.SetActive(true);
        bestScoreTMP.text = "Best Score = " + PlayerPrefs.GetInt("Best"); 
        bestScoreTMP.gameObject.SetActive(true);
    }
    
}

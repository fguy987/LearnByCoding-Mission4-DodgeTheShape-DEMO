using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUIHandler : MonoBehaviour
{
    
    private Button retryButton, returnButton;
    private AudioSource pressSound;


    private void Awake()
    {
        pressSound = GetComponent<AudioSource>();

        Button[] buttons = GetComponentsInChildren<Button>();
        retryButton = buttons[0];
        returnButton = buttons[1];

        retryButton.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(ReturnToMenu);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        pressSound.Play();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    private void ReturnToMenu()
    {
        pressSound.Play();
        SceneManager.LoadScene(0);
    }

}

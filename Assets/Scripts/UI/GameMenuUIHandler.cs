using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUIHandler : MonoBehaviour
{
    
    private Button retryButton, returnButton;
    private AudioSource pressSound, gameMusic;

    private float gameMusicCurrentMax;


    private void Awake()
    {
        pressSound = GetComponent<AudioSource>();
        AudioSource[] gameMusics = GetComponentsInParent<AudioSource>(); //There seems to be a bug where it also grabs own Audiosource along with parents' audioSource
        gameMusic = gameMusics[1];
        gameMusicCurrentMax = gameMusic.volume;

        Button[] buttons = GetComponentsInChildren<Button>();
        retryButton = buttons[0];
        returnButton = buttons[1];

        retryButton.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(ReturnToMenu);
    }

    private void Start()
    {
        gameMusic.Play();
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

    public void Pause()
    {
        gameMusic.volume = 0.3f* gameMusicCurrentMax;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        gameMusic.volume = gameMusicCurrentMax;
        Time.timeScale = 1f;
    }
}

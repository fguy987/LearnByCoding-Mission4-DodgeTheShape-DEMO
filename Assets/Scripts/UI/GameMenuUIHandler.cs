using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenuUIHandler : MonoBehaviour
{
    
    private Button retryButton, returnButton;
    private AudioSource pressSound, gameMusic;
    [SerializeField] //set in editor
    private GameObject gameOver_Obj;
    [SerializeField] //set in editor
    private GameObject score_Obj;
    private TMP_Text scoreTMP;

    private float gameMusicCurrentMax;


    private void Awake()
    {
        Time.timeScale = 1f;

        //audio
        pressSound = GetComponent<AudioSource>();
        AudioSource[] gameMusics = GetComponentsInParent<AudioSource>(); //There seems to be a bug where it also grabs own Audiosource along with parents' audioSource
        gameMusic = gameMusics[1];
        gameMusicCurrentMax = gameMusic.volume;

        //Buttons
        Button[] buttons = GetComponentsInChildren<Button>();
        retryButton = buttons[0];
        returnButton = buttons[1];

        retryButton.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(ReturnToMenu);

        //Score
        scoreTMP= score_Obj.GetComponentInChildren<TMP_Text>();

        //GameOver
        gameOver_Obj.SetActive(false);
    }

    private void Start()
    {
        gameMusic.Play();
        gameObject.SetActive(false);
    }

    //Score Keeping
    public void UpdateScoreUI(int scoreToDisplay)
    {
        scoreTMP.text = $"Shapes Dodged: {scoreToDisplay}";

    }

    //Pause Menu
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

    public void GameOver()
    {
        Pause();
        gameOver_Obj.SetActive(true);

    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Class wrapping Functionalities related to Main Menu UI Buttons
/// </summary>
public class MainMenuUIHandler : MonoBehaviour
{
    private Button startButton, exitButton;
    private AudioSource pressSound;
    private void Awake()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        startButton = buttons[0];
        exitButton = buttons[1];

        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);

        pressSound = GetComponent<AudioSource>();
    }
    private void StartGame()
    {
        pressSound.Play();
        SceneManager.LoadScene(1);

    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}

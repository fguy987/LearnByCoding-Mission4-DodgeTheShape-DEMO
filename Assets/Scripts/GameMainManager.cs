using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }

    private void GameOver()
    {
        Time.timeScale = 0f;

    }
}

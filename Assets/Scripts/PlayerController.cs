using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameMenu_Obj;
    private GameMenuUIHandler GameMenuUIHandler;

    private Rigidbody2D rb2d;

    private float horInput,vertInput,speed;
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        GameMenuUIHandler = gameMenu_Obj.GetComponent<GameMenuUIHandler>();
        rb2d =GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        horInput  = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) 
            {
                OpenMenu();
            }
            else 
            { 
                CloseMenu(); 
            }
            isPaused = !isPaused;
        }

    }


    private void OpenMenu()
    {
        gameMenu_Obj.SetActive(true);
        GameMenuUIHandler.Pause();
    }
    private void CloseMenu()
    {
        GameMenuUIHandler.Resume();
        gameMenu_Obj.SetActive(false);
    }

    
    


    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2 (speed*horInput, speed*vertInput);
    }


}

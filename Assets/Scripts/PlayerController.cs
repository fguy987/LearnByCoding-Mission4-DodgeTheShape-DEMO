using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameMenu_Obj;
    
    private Rigidbody2D rb2d;

    private float horInput,vertInput,speed;
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        horInput  = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) { Pause(); }
            else { Resume(); }
        }

    }
    private void Pause()
    {
        gameMenu_Obj.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        gameMenu_Obj.SetActive(false);
        Time.timeScale = 1f;
    }


    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2 (speed*horInput, speed*vertInput);
    }


}

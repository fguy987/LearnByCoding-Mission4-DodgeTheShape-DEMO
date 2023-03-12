using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Collider2D coll;
    protected Player player;
    protected ScoreManager scoreManager;

    //ENCAPSULATION
    protected Vector2 destination;
    private float horDest = 12f; //is set by a public method after basic checks
    private float vertDest = 7f;
    protected int damage =  1; 
    protected int pointsWorth =1;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreManager>();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //ABSTRACTION
        MovePattern();
    }

    //ENCAPSULATION
    public void SetDestination(SpawnSide side, Vector2 spawnPoint)
    {
        switch (side)
        {
            case SpawnSide.Left:
                destination = new Vector2(horDest, spawnPoint.y);
                break;
            case SpawnSide.Right:
                destination = new Vector2(-horDest, spawnPoint.y); ;
                break;
            case SpawnSide.Up:
                destination = new Vector2(spawnPoint.x, -vertDest);
                break;
            case SpawnSide.Down:
                destination = new Vector2(spawnPoint.x, vertDest);
                break;
            default:
                Debug.Log("ERROR: Unknown side!");
                break;
        }
        //Debug.Log($"spawn point {spawnPoint} dest chosen{destination}");
    }

    
    protected abstract void MovePattern();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamagePlayer();
        }
        
        if (collision.CompareTag("ObjDestr"))
        {
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        scoreManager.AddScore(pointsWorth);
        Destroy(gameObject);
    }


    //ABSTRACTION
    private void DamagePlayer()
    {
        player.TakeDamage(damage);
        Destroy(gameObject);
    }
}

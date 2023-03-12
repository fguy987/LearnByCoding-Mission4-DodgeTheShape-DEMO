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
    private Vector2 destination;
    public Vector2 Destination 
    {
        get { return destination; }

        private set //private setting of the property is done by SetDestination method 
        {
            destination = value;
        }
        
    }
    private float horDest = 12f; 
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
                Destination = new Vector2(horDest, spawnPoint.y);
                break;
            case SpawnSide.Right:
                Destination = new Vector2(-horDest, spawnPoint.y); ;
                break;
            case SpawnSide.Up:
                Destination = new Vector2(spawnPoint.x, -vertDest);
                break;
            case SpawnSide.Down:
                Destination = new Vector2(spawnPoint.x, vertDest);
                break;
            default:
                Debug.Log("ERROR: Unknown side!");
                break;
        }
    }

    
    protected abstract void MovePattern();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ABSTRACTION
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

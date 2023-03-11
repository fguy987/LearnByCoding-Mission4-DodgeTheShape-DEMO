using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Collider2D coll;

    //ENCAPSULATION
    protected Vector2 destination;
    private float horDest = 12f;
    private float vertDest = 7f;
    protected float damage = 0f; //is set by child classes 

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
    }

    //ABSTRACTION
    private void DamagePlayer()
    {
        Debug.Log($"Deal {damage} to player");

    }
}

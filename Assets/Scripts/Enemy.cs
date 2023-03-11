using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Collider2D coll;
    private Player player; 

    //ENCAPSULATION
    protected Vector2 destination;
    private float horDest = 12f; //is set by a public method after basic checks
    private float vertDest = 7f;
    protected int damage = 0; //is set by child classes 

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
    }


    //ABSTRACTION
    private void DamagePlayer()
    {
        player.TakeDamage(damage);

    }
}

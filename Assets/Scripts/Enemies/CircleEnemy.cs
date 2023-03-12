using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : Enemy
{
    private Transform playerTr;
    private Vector2 wayToDest;
    private float speed = 3.5f;

    protected override void Start()
    {
        base.Start();
        playerTr = player.GetComponent<Transform>();
        StartCoroutine(DeathTimer());
        damage = 1;
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    protected override void MovePattern()
    {
        wayToDest = new Vector2(playerTr.position.x - transform.position.x, playerTr.position.y - transform.position.y);
        transform.Translate(speed * Time.deltaTime * wayToDest.normalized);
    }

}

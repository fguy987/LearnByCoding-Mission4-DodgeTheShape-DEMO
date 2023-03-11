using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemy : Enemy
{

    private Vector2 wayToDest;
    private float speed = 5f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        damage = 1f; 
    }

    //POLYMORPHISM
    protected override void MovePattern()
    {
        wayToDest = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        transform.Translate(speed * Time.deltaTime * wayToDest.normalized);
    }
}

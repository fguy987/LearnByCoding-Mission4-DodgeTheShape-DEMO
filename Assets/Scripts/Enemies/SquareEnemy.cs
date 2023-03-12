using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//INHERITANCE
public class SquareEnemy : Enemy
{

    private Vector2 wayToDest;
    private float speed = 5f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        damage = 1; 
        wayToDest = new Vector2(Destination.x - transform.position.x, Destination.y - transform.position.y);
    }

    //POLYMORPHISM
    protected override void MovePattern()
    {
        transform.Translate(speed * Time.deltaTime * wayToDest.normalized);
    }
}

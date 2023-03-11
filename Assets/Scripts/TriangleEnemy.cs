using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemy : Enemy
{
    private Vector2 pathToDest= Vector2.zero;
    private float speed = 6f;

    protected override void Start()
    {
        base.Start();
        damage = 2;
        StartCoroutine(switchVelocityAfterTimer());
    }

    protected override void MovePattern()
    {
        transform.Translate(speed * Time.deltaTime * pathToDest.normalized);
    }

    private IEnumerator switchVelocityAfterTimer()
    {
        Vector2 wayToDestNorm = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        float angle = 30f;
        while(true)
        {
            pathToDest = RotateVector2D(wayToDestNorm, angle);
            angle = -angle;
            yield return new WaitForSeconds(1f);
        }
    }

    public Vector2 RotateVector2D(Vector2 v, float angDeg)
    {
        float angle = angDeg * Mathf.Deg2Rad;
        return new Vector2((v.x * Mathf.Cos(angle) - v.y * Mathf.Sin(angle)), (v.x * Mathf.Sin(angle) + v.y * Mathf.Cos(angle)));
    }
}

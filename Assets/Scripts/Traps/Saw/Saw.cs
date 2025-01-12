using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : EnemyPatrol
{
    void Start()
    {

        targetPoint = 0;
        speedPatrol = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, points[targetPoint].position) < 0.5f)
        {
            targetPoint++;
            //base.Flip();
            if (targetPoint >= points.Length)
                targetPoint = 0;
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
            points[targetPoint].position, speedPatrol * Time.deltaTime);
        }
    }
}

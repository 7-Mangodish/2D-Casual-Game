using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPatrol : EnemyPatrol
{
    // Start is called before the first frame update
    void Start()
    {
        cntPoints = points.GetLength(0);
        targetPoint = 0;
        speedPatrol = 4;
        timeIdle = 2;
        timeDuration = 0f;
        anim.Play("Run");
        Physics2D.IgnoreLayerCollision(8, 8, true);

    }

    // Update is called once per frame
    void Update()
    {
        base.Move();
    }
}

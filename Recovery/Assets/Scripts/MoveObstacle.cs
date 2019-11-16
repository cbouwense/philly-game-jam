using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public Rigidbody2D rb2d;

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(1, 0);
    }
}

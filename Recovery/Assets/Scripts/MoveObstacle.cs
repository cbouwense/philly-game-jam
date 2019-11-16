using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int speed;

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed, 0);
    }
}

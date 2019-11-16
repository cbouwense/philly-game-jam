using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float speed;

    private void Start()
    {
        speed = Random.Range(3.0f, 7.0f);
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed, 0);
    }
}

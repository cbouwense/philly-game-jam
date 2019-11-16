using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    private int speed = 5;
    private int jumpVelocity = 10;
    private bool moveable = true;

    protected override void ComputeVelocity()
    {
        // Horizontal Input
        if (moveable)
        {
            velocityX = Input.GetAxisRaw("Horizontal");

            if (velocityX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (velocityX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            velocityX *= speed;

        }

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            // If we're on the ground, jump normally
            if (grounded)
            {
                velocity.y = jumpVelocity;
                //sm.PlaySound("jump_sound");
            }
        }
    }

    protected override void Update()
    {
        base.Update();
    }
}

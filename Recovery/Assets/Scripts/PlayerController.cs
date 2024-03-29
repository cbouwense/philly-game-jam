﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    private int speed = 5;
    private int jumpVelocity = 16;
    private bool moveable = true;
    public Animator animator;
    public SoundManager sm;
    public FlashBang fb;
    public ShakeBehavior sb;
    public float recoverTimer = 21.0f;
    public float recoverCooldown = 15.0f;

    protected override void ComputeVelocity()
    {
        // Horizontal Input
        if (moveable)
        {
            velocityX = Input.GetAxisRaw("Horizontal");

            if (velocityX > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                if (grounded)
                {
                    sm.PlaySound("run_sound");
                }
            }
            else if (velocityX < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                if (grounded)
                {
                    sm.PlaySound("run_sound");
                }
            }

            animator.SetBool("moving", velocityX != 0);
            velocityX *= speed;

        }

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            // If we're on the ground, jump normally
            if (grounded)
            {
                velocity.y = jumpVelocity;
                sm.PlaySound("jump_sound");
            }
        }

        // Recover ("panic" button)
        if (Input.GetButtonDown("Recover") && recoverTimer > recoverCooldown)
        {
            recoverTimer = 0;
            GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject ob in obs)
                GameObject.Destroy(ob);
            fb.MineHit();
            sb.TriggerShake();
            sm.PlaySound("recover_sound");

        }
    }

    protected override void Update()
    {
        base.Update();
        if (recoverTimer <= recoverCooldown)
        {
            recoverTimer += Time.deltaTime;
        }
    }
}

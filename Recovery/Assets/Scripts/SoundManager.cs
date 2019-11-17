﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip runSound, jumpSound, eggSound, nextLevelSound, pickupSound;
    static AudioSource audioSrc;
    private float walkTimer, jumpTimer, eggTimer, nextLevelTimer, pickupTimer;

    void Start()
    {

        runSound = Resources.Load<AudioClip>("goat_run_cycle");
        jumpSound = Resources.Load<AudioClip>("goat_jump");

        audioSrc = gameObject.GetComponent<AudioSource>();

        walkTimer = 0.0f;
        jumpTimer = 0.0f;

    }

    void Update()
    {
        if (walkTimer > 0)
            walkTimer -= Time.deltaTime;
        if (jumpTimer > 0)
            jumpTimer -= Time.deltaTime;
    }

    public void PlaySound(string clip)
    {
        audioSrc.volume = 0.5f;
        switch (clip)
        {
            case "run_sound":
                Debug.Log("run sound!");
                if (walkTimer <= 0)
                {
                    audioSrc.PlayOneShot(runSound);
                    walkTimer = 0.35f;
                }
                break;

            case "jump_sound":
                Debug.Log("jump sound!");
                if (jumpTimer <= 0)
                {
                    audioSrc.PlayOneShot(jumpSound);
                    jumpTimer = 0.1f;
                }
                break;
        }
    }
}

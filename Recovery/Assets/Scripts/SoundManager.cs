using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip runSound, jumpSound, eggSound, nextLevelSound, pickupSound, dieSound, recoverSound, landSound;
    static AudioSource audioSrc;
    private float walkTimer, jumpTimer, nextLevelTimer, pickupTimer;

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        transform.parent = null;
    }

    void Start()
    {

        runSound = Resources.Load<AudioClip>("goat_run_cycle");
        jumpSound = Resources.Load<AudioClip>("goat_jump");
        landSound = Resources.Load<AudioClip>("goat_land_1");
        dieSound = Resources.Load<AudioClip>("goat_fall_newfx1");
        recoverSound = Resources.Load<AudioClip>("goat_belt_2");

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

            case "die_sound":
                Debug.Log("die sound!");
                audioSrc.PlayOneShot(dieSound);
                break;
            case "recover_sound":
                Debug.Log("recover sound!");
                audioSrc.PlayOneShot(recoverSound);
                break;
            case "land_sound":
                Debug.Log("land sound!");
                audioSrc.PlayOneShot(landSound);
                break;
        }
    }
}

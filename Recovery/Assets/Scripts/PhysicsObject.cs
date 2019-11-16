using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjects : MonoBehaviour
{
    [SerializeField] protected float minGroundNormalY = 0.65f;
    [SerializeField] protected float gravityModifier = 2f;

    public bool grounded, wasGrounded, jump;
    protected Vector2 groundNormal;
    public float velocityX, velocityY;
    protected Rigidbody2D rb2d;
    public Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    //protected Animator anim;
    //protected StatsController stats;
    //protected PlayerController pc;
    //protected SoundManager sm;
    //private AudioSource audioSource;

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    protected virtual void Start()
    {

        // Ignore any contacts involving trigger colliders
        contactFilter.useTriggers = false;

        // Use layer that object is on
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));

        rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //stats = GetComponent<StatsController>();
        //pc = GetComponent<PlayerController>();
        //sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        //audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        ComputeVelocity();
        jump = Input.GetButtonDown("Jump");
    }

    protected virtual void ComputeVelocity()
    {

    }

    protected virtual void FixedUpdate()
    {
        //if (anim && tag == "Birb")
        //    resetAnim();

        // Update y
        //velocity.y += Physics2D.gravity.y * (stats.getCurrentGrav()) * Time.deltaTime;
        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        // Update x
        velocity.x = velocityX;

        // Reset grounded value
        wasGrounded = grounded;
        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move;

        // Apply changes in position
        move = moveAlongGround * deltaPosition.x;
        Movement(move, 'x');

        move = Vector2.up * deltaPosition.y;
        Movement(move, 'y');

        /*
        if (anim && tag == "Birb")
        {
            // Animator logic
            anim.SetFloat("velX", velocity.x);
            anim.SetFloat("velY", velocity.y);
            anim.SetBool("grounded", grounded);
        }

        if (grounded && velocity.x != 0)
        {
            sm.PlaySound("run_sound");
        }
        */
    }

    protected void Movement(Vector2 move, char axis)
    {

        // Distance that object is going to move
        float distance = move.magnitude;

        // Only check for collision if we are trying to move 
        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);

            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                // Vector perpendicular to the RayCast which detected collision and with what it collided
                Vector2 currentNormal = hitBufferList[i].normal;

                // If what we collided with is flat enough to be considered ground
                if (currentNormal.y > minGroundNormalY)
                {

                    // Set grounded equal to true
                    grounded = true;
     
                    // Become moveable again
                    //stats.setMoveable(true);

                    // If we are modifying the object's y coordinate
                    if (axis == 'y')
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }

                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity -= projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                if (modifiedDistance < distance)
                {
                    distance = modifiedDistance;
                }
            }
        }

        if (distance != -0.01f)
            rb2d.position += move.normalized * distance;

    }

    /*
    public void resetAnim()
    {
        string[] states = { "grounded", "layEgg" };
        for (int i = 0; i < states.Length; i++)
        {
            anim.SetBool(states[i], false);
        }
    }
    */
}

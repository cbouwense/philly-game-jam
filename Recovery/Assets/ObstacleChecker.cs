using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x - 1, transform.position.y),
            Vector2.left, 
            0.05f);

        Debug.DrawLine(
            transform.position,
            new Vector2(transform.position.x - 1, transform.position.y),
            Color.white);

        // If we are not colliding with anything
        if (hit.collider == null)
        {
            Debug.Log("not hitting anything");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

}

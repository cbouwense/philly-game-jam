using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D col)
    {
        RoomController rc = GameObject.Find("RoomManager").GetComponent<RoomController>();

        if (col.tag == "Player")
        {
            Debug.Log("Colliding with player!");
            rc.restartLevel();
        }

        if (col.tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }
    }
}

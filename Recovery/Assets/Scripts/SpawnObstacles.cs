using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private float group1spawnTimer = 0.0f;
    
    public GameObject ob1;
    // Update is called once per frame
    void Update()
    {
        group1spawnTimer += Time.deltaTime;

        if (group1spawnTimer > 5)
        {
            group1spawnTimer = 0.0f;
            SpawnObstacle(1, new Vector2(-10, -0.45f));
        }
    }

    void SpawnObstacle(int num, Vector2 pos)
    {
        if (num == 1)
        {
            Instantiate(ob1, pos, new Quaternion());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private float group1spawnTimer = 0.0f;
    private float group2spawnTimer = 0.0f;
    private float group3spawnTimer = 0.0f;
    private int currentTimer = 1;
    private float cooldown = 2;
    private float cooldownModifier = 0;

    public GameObject ob1, ob2, ob3;
    // Update is called once per frame
    void Update()
    {
        if (cooldownModifier < 3)
        {
            cooldownModifier += 0.001f;
        }
        if (currentTimer == 1)
            group1spawnTimer += Time.deltaTime;
        if (currentTimer == 2)
            group2spawnTimer += Time.deltaTime;
        if (currentTimer == 3)
            group3spawnTimer += Time.deltaTime;

        if (group1spawnTimer > cooldown)
        {
            cooldown = Random.Range(0, 3) - cooldownModifier + 0.5f;
            group1spawnTimer = 0.0f;
            currentTimer = 2;
            SpawnGroup(1);
        }
        if (group2spawnTimer > cooldown)
        {
            cooldown = Random.Range(0, 3) - cooldownModifier + 0.5f;
            group2spawnTimer = 0.0f;
            currentTimer = 3;
            SpawnGroup(2);
        }
        if (group3spawnTimer > cooldown)
        {
            cooldown = Random.Range(0, 3) - cooldownModifier + 0.5f;
            group3spawnTimer = 0.0f;
            currentTimer = 1;
            SpawnGroup(3);
        }
    }

    void SpawnGroup(int group)
    {
        if (group == 1)
        {
            SpawnObstacle(2, new Vector2(-10, -0.45f));
        }
        else if (group == 2)
        {
            SpawnObstacle(1, new Vector2(-10, -0.9f));
            SpawnObstacle(1, new Vector2(-10, 2f));
        }
        else if (group == 3)
        {
            SpawnObstacle(1, new Vector2(-9, -0.9f));
            SpawnObstacle(2, new Vector2(-11, -0.45f));
            SpawnObstacle(3, new Vector2(-13, 0.1f));
        }
    }

    void SpawnObstacle(int num, Vector2 pos)
    {
        if (num == 1)
        {
            Instantiate(ob1, pos, new Quaternion());
        }
        else if (num == 2)
        {
            Instantiate(ob2, pos, new Quaternion());
        }
        else if (num == 3)
        {
            Instantiate(ob3, pos, new Quaternion());
        }
    }
}

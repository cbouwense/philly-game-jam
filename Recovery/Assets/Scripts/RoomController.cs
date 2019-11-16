using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private SpawnerController spawner;
    //[SerializeField] private StatsController playerStats;

    void Start () {

        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            try
            {
                //spawner = GameObject.Find("playerSpawner").GetComponent<SpawnerController>();
            }
            catch
            {
                Debug.Log("Spawner not found, will try again in Update()");
            }

            /*
            if (spawner)
                player = spawner.getplayer();
            if (player)
                playerStats = player.GetComponent<StatsController>();
            if (playerStats)
                playerStats.setEggMax(eggCount);
            */
        }

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
    }
	
	void Update () {

        // If we're not in the main menu
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            // Keep trying to get the ref if you dont have it
            /*
            if (!spawner)
                spawner = GameObject.Find("playerSpawner").GetComponent<SpawnerController>();
            if (!player)
                player = spawner.getplayer();
            if (!playerStats)
                playerStats = player.GetComponent<StatsController>();
            if (playerStats)
                playerStats.setEggMax(eggCount);
            */

            // Restart Input
            if (Input.GetButtonDown("Restart"))
            {
                Debug.Log("Restarting level");
                restartLevel();
            }
           
        }

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

}

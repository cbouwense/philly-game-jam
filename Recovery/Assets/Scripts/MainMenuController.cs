using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame () 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log ("quiting my life 🤣");
        Application.Quit();
    }

    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            QuitGame();
        }
    }
}

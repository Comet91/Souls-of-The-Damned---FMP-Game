using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Retry()
    {
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

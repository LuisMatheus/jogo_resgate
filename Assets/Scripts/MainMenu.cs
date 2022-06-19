using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject optMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(2);
    }

    public void QuitGame()
    {
        Debug.Log("Closing Application");
        Application.Quit();
    }
}
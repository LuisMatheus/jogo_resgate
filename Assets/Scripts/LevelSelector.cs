using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    public string newScene;

   public void InicarLevel()
    {
        SceneManager.LoadScene(newScene);
    }
}

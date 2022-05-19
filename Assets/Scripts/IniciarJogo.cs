using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJogo : MonoBehaviour
{
    public void newGame()
    {
        GameObject[] titulo = GameObject.FindGameObjectsWithTag("Title");
        
        titulo[0].transform.Translate(0, 250, 0);

        GameObject g = GameObject.Find("startButton");
        g.SetActive(false);

        GameObject[] levels = GameObject.FindGameObjectsWithTag("LevelCardCanvas");

        foreach(GameObject level in levels){
            var x = level.GetComponent<CanvasGroup>();
            x.alpha = 1;
            x.interactable = true;
            x.blocksRaycasts = true;
        }

        
    }
}

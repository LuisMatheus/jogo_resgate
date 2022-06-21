using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getScoreSccene : MonoBehaviour
{
    public int pontos;
    public Text pontosDisplay;

    void Start()
    {
        pontos = PickItem.score;
        pontosDisplay.text = pontos.ToString();
        
    }

    
}

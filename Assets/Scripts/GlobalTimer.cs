using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GlobalTimer : MonoBehaviour
{

    public Text timeToFinishDisplay;
    public float timeToFinish = 60 * 10; // 10 Minutes
    public GameOver gameOver;


    // Update is called once per frame
    void Update()
    {

        timeToFinish = timeToFinish - Time.deltaTime;

        if (timeToFinish > 0)
        {
            TimeSpan time = TimeSpan.FromSeconds(timeToFinish);
            timeToFinishDisplay.text = time.ToString(@"mm\:ss");
        }

        else
        {
            gameOver.gameOver();
        }


    }

}

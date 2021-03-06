using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{

    public Text waterTimingDisplay;
    public float waterTiming = 60;
    public GameOver gameOver;

    void Start()
    {
        waterTiming = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // waterTimingDisplay.text = waterTiming.ToString();
        waterTiming = waterTiming - Time.deltaTime;

        if (waterTiming > 0)
        {
            waterTimingDisplay.text = waterTiming.ToString();
        }

        else
        {
            waterTimingDisplay.text = "Fim de jogo!";
            gameOver.gameOver();
        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("water") == true)
        {
            waterTiming = 60;
            Destroy(col.gameObject);
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    public Text scoreDisplay;
    public Text axeDisplay;
    public Text bandageDisplay;    
    public int score;
    public int axeCount;
    public int bandageCount;

    void Start()
    {
        score = 0;
        axeCount = 0;
        bandageCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
        axeDisplay.text = axeCount.ToString();
        bandageDisplay.text = bandageCount.ToString();
        
    }

    private void OnTriggerEnter(Collider col) {
        if (col.CompareTag("axe")==true) {
            score = score + 1;
            axeCount = axeCount + 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("bandage")==true) {
            score = score + 1;
            bandageCount = bandageCount + 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("saveByBandage")==true && bandageCount>0) {
            score = score + 1;
            bandageCount = bandageCount - 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("saveByAxe")==true && axeCount>0) {
            score = score + 1;
            axeCount = axeCount - 1;
            Destroy(col.gameObject);
        }


    }

}

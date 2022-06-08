using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    public Text scoreDisplay;
    public Text axeDisplay;
    public Text ropeDisplay;
    public int score;
    public int axeCount;
    public int ropeCount;

    void Start()
    {
        score = 0;
        axeCount = 0;
        ropeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
        axeDisplay.text = axeCount.ToString();
        ropeDisplay.text = ropeCount.ToString();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("axe") == true)
        {
            axeCount = axeCount + 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("rope") == true)
        {
            ropeCount = ropeCount + 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("saveByRope") == true && ropeCount > 0)
        {
            score = score + 1;
            ropeCount = ropeCount - 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("saveByAxe") == true && axeCount > 0)
        {
            score = score + 1;
            axeCount = axeCount - 1;
            Destroy(col.gameObject);
        }


    }

}

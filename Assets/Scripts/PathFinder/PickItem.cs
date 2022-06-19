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
    public int ervaCount;
    public int aguaCount;

    void Start()
    {
        score = 0;
        axeCount = 30;
        ropeCount = 30;
        ervaCount = 30;
        aguaCount = 30;
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

        if (col.CompareTag("Regatado") == true)
        {
            var resgatado = col.gameObject.GetComponent<ResgatadoScript>();

            if (resgatado.agua <= aguaCount && resgatado.corda <= ropeCount && resgatado.erva <= ervaCount && resgatado.machado <= axeCount)
            {
                aguaCount = aguaCount - resgatado.agua;
                ropeCount = ropeCount - resgatado.corda;
                ervaCount = ervaCount - resgatado.erva;
                axeCount = axeCount - resgatado.machado;
                Destroy(col.gameObject);
                score = score + 1;

            }
        }


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


    }

}

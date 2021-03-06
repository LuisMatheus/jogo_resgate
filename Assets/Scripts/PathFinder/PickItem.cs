using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    public Text scoreDisplay;
    public Text axeDisplay;
    public Text ropeDisplay;
    public Text knifeDisplay;

    public Text ervaDisplay;

    public static int score = 0;
    public int axeCount;
    public int ropeCount;
    public int ervaCount;
    public int knifeCount;

    public int ropeNeed;
    public int axeNeed;
    public int knifeNeed;
    public int ervaNeed;

    public Text ropeNeedDisplay;
    public Text axeNeedDisplay;
    public Text ervaNeedDisplay;
    public Text knifeNeedDisplay;

    public GameObject telaResgate;

    public Collider collider;

    void Start()
    {
        telaResgate = GameObject.Find("TelaResgate");
        telaResgate.SetActive(false);

        score = 0;
        axeCount = 0;
        ropeCount = 0;
        ervaCount = 0;
        knifeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Scores: " + score.ToString();
        axeDisplay.text = axeCount.ToString();
        ropeDisplay.text = ropeCount.ToString();
        ervaDisplay.text = ervaCount.ToString();
        knifeDisplay.text = knifeCount.ToString();

        ervaNeedDisplay.text = "Erva(s): " + ervaNeed.ToString();
        ropeNeedDisplay.text = "Corda(s): " + ropeNeed.ToString();
        axeNeedDisplay.text = "Machado(s): " + axeNeed.ToString();
        knifeNeedDisplay.text = "Faca(s): " + knifeNeed.ToString();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            telaResgate.SetActive(false);
        }

        if (collider)
        {
            var resgatado = collider.gameObject.GetComponent<ResgatadoScript>();
            if (Input.GetKeyDown(KeyCode.E) && resgatado.knife <= knifeCount && resgatado.corda <= ropeCount && resgatado.erva <= ervaCount && resgatado.machado <= axeCount)
            {

                //Destroy(collider.gameObject);
                telaResgate.SetActive(false);
                score = score + resgatado.knife + resgatado.corda + resgatado.erva + resgatado.machado;

                knifeCount = knifeCount - resgatado.knife;
                ropeCount = ropeCount - resgatado.corda;
                ervaCount = ervaCount - resgatado.erva;
                axeCount = axeCount - resgatado.machado;
                GameObject.Find("ResgatadoSpawner").GetComponent<ResgatadoSpawnerScript>().removerResgatado(resgatado.gameObject, true);
            }

        }
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Regatado") == true)
        {
            collider = col;
            var resgatado = collider.gameObject.GetComponent<ResgatadoScript>();
            knifeNeed = resgatado.knife;
            ropeNeed = resgatado.corda;
            ervaNeed = resgatado.erva;
            axeNeed = resgatado.machado;
            telaResgate.SetActive(true);

            // desabilita text relacionado a agua
            // if (aguaNeed == 0)
            // {
            //     aguaNeedDisplay.gameObject.SetActive(false);
            // }
            // else
            // {
            //     if (aguaNeed > 0)
            //     {
            //         aguaNeedDisplay.gameObject.SetActive(true);
            //     }
            // }


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

        if (col.CompareTag("herb") == true)
        {
            ervaCount = ervaCount + 1;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("knife") == true)
        {
            knifeCount = knifeCount + 1;
            Destroy(col.gameObject);
        }


    }

    private void OnTriggerExit(Collider col)
    {


        if (col.CompareTag("Regatado") == true)
        {
            collider = null;
        }

    }

}
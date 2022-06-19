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
    public GameObject telaResgate;

    public Collider collider;

    public bool podeDestruir = false;

    void Start()
    {
        telaResgate = GameObject.Find("TelaResgate");
        telaResgate.SetActive(false);

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collider.gameObject);
            telaResgate.SetActive(false);
            score = score + 1;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        collider = col;

        if (col.CompareTag("Regatado") == true)
        {
            telaResgate.SetActive(true);

            var resgatado = col.gameObject.GetComponent<ResgatadoScript>();

            Debug.Log("Agua " + resgatado.agua + " Corda " + resgatado.corda + " Erva " + resgatado.erva + " Machado " + resgatado.machado);

            if (resgatado.agua <= aguaCount && resgatado.corda <= ropeCount && resgatado.erva <= ervaCount && resgatado.machado <= axeCount)
            {
                aguaCount = aguaCount - resgatado.agua;
                ropeCount = ropeCount - resgatado.corda;
                ervaCount = ervaCount - resgatado.erva;
                axeCount = axeCount - resgatado.machado;
                podeDestruir = true;

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

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Regatado"))
        {
            telaResgate.SetActive(false);
        }

    }

}

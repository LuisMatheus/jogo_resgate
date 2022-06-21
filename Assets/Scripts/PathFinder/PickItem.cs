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

    public int aguaNeed;
    public int ropeNeed;
    public int ervaNeed;
    public int axeNeed;
    public Text aguaNeedDisplay;   
    public GameObject telaResgate;

    public Collider collider;
    

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
        aguaNeedDisplay.text = aguaNeed.ToString();
        
        if (Input.GetKeyDown(KeyCode.E) && collider)
        {
            //Destroy(collider.gameObject);
            telaResgate.SetActive(false);
            score = score + 1;
            var resgatado = collider.gameObject.GetComponent<ResgatadoScript>();
            

            Debug.Log("Agua " + resgatado.agua + " Corda " + resgatado.corda + " Erva " + resgatado.erva + " Machado " + resgatado.machado);

            if (resgatado.agua <= aguaCount && resgatado.corda <= ropeCount && resgatado.erva <= ervaCount && resgatado.machado <= axeCount)
            {
                aguaCount = aguaCount - resgatado.agua;
                ropeCount = ropeCount - resgatado.corda;
                ervaCount = ervaCount - resgatado.erva;
                axeCount = axeCount - resgatado.machado;
                GameObject.Find("ResgatadoSpawner").GetComponent<ResgatadoSpawnerScript>().removerResgatado(resgatado.gameObject,true);
            }
        }

       
    }

    private void OnTriggerEnter(Collider col)
    {
    
        if (col.CompareTag("Regatado") == true)
        {
            collider = col;
            var resgatado = collider.gameObject.GetComponent<ResgatadoScript>();
           aguaNeed = resgatado.agua;
            ropeNeed = resgatado.corda;
            ervaNeed = resgatado.erva;
            axeNeed = resgatado.machado;
            telaResgate.SetActive(true);

            // desabilita text relacionado a agua
            if (aguaNeed == 0)
            {
                aguaNeedDisplay.gameObject.SetActive(false);
            }
            else
            {
                if (aguaNeed > 0)
                {
                    aguaNeedDisplay.gameObject.SetActive(true);
                }
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
            collider = null;
            telaResgate.SetActive(false);
        }

    }

}
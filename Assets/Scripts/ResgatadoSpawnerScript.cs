using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResgatadoSpawnerScript : MonoBehaviour
{

    public GameObject resgatado;

    public List<GameObject> quadrantes;

    public int quantidade_regatados;

    private List<GameObject> resgatados = new List<GameObject>();

    private Dictionary<GameObject, int> resgatadoTracker = new Dictionary<GameObject, int>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject element in quadrantes)
        {
            resgatadoTracker.Add(element, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var item in resgatadoTracker)
        {
            if (item.Value < quantidade_regatados)
            {
                spawnResgatado();
                resgatadoTracker[item.Key] = resgatadoTracker[item.Key] +1;
            }
        }

        
    }

    void spawnResgatado()
    {
        GameObject res = GameObject.Instantiate(resgatado);

        //Seta os itens
        res.GetComponent<ResgatadoScript>().agua = 1;
        res.GetComponent<ResgatadoScript>().machado = 1;
        res.GetComponent<ResgatadoScript>().erva = 1;
        res.GetComponent<ResgatadoScript>().corda = 1;

        res.transform.SetParent(this.transform,false);
        setPosicao(res,5,7);

    }

    void setPosicao(GameObject resgatado, float x, float z)
    {
       UnityEngine.AI.NavMeshHit hit;

        float i = 15;

        while (!UnityEngine.AI.NavMesh.SamplePosition(new Vector3(x,i,z), out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            i = i - 0.5f;
        }
        resgatado.transform.position = hit.position + new Vector3(0, resgatado.transform.localScale.y, 0);

    }

}

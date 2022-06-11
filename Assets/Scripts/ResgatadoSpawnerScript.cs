using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResgatadoSpawnerScript : MonoBehaviour
{

    public GameObject resgatado;

    public List<GameObject> quadrantes;

    public int quantidade_regatados;
    
    private Dictionary<GameObject, List<GameObject>> resgatadoTracker = new Dictionary<GameObject, List<GameObject>>();

    private Vector3[] aux;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject element in quadrantes)
        {
                resgatadoTracker.Add(element.gameObject, new List<GameObject>());        
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < resgatadoTracker.Count; i++)
        {
            var item = resgatadoTracker.ElementAt(i);
             if (item.Value.Count < quantidade_regatados)
            {
                item.Value.Add(spawnResgatado(quadrantes[i]));
            }      
        }
      

        
    }

    GameObject spawnResgatado(GameObject plane)
    {
        GameObject res = GameObject.Instantiate(resgatado);

        //Seta os itens
        res.GetComponent<ResgatadoScript>().agua = 1;
        res.GetComponent<ResgatadoScript>().machado = 1;
        res.GetComponent<ResgatadoScript>().erva = 1;
        res.GetComponent<ResgatadoScript>().corda = 1;
        res.GetComponent<ResgatadoScript>().vida = Random.Range(0,99);

        
        res.transform.SetParent(this.transform,false);
        aux = plane.GetComponent<VerticeCollector>().vertices;
        res.transform.position = plane.transform.TransformPoint(aux[Random.Range(0,aux.Length-1)]) + new Vector3(0,0.5f,0);

        return res;
    }

    public void removerResgatado(GameObject resgatado)
    {
        for (int i = 0; i < resgatadoTracker.Count; i++)
        {
            if (resgatadoTracker[quadrantes[i]].Contains(resgatado))
            {
                resgatadoTracker[quadrantes[i]].Remove(resgatado);
                Destroy(resgatado);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("player"))
        {
            Debug.Log("FOI!");
        }
    }
}

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

    public int quantidadeRegatados;
    
    private Dictionary<GameObject, List<GameObject>> resgatadoTracker = new Dictionary<GameObject, List<GameObject>>();

    private Vector3[] aux;

    public int updateLevel = 4;

    public int offSetTempoVida = 1;
    
    private int resgatadosNum = 1;
    
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
             if (item.Value.Count < quantidadeRegatados)
            {
                item.Value.Add(spawnResgatado(quadrantes[i]));
            }      
        }
      

        
    }

    GameObject spawnResgatado(GameObject plane)
    {
        GameObject res = GameObject.Instantiate(resgatado);

        //Seta os itens
        res.GetComponent<ResgatadoScript>().agua = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().machado = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().erva = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().corda = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().vida = vidaSpawn();

        updateQuantidadeResgatados();
        
        res.transform.SetParent(this.transform,false);
        aux = plane.GetComponent<VerticeCollector>().vertices;
        res.transform.position = plane.transform.TransformPoint(aux[Random.Range(0,aux.Length-1)]) + new Vector3(0,0.5f,0);

        return res;
    }

    private float vidaSpawn()
    {
        return 90 / (resgatadosNum * offSetTempoVida);
    }

    private void updateQuantidadeResgatados()
    {
        var x = resgatadosNum % updateLevel;
        quantidadeRegatados = x == 0 ? 1 : x;
    }

    public void removerResgatado(GameObject resgatado)
    {
        for (int i = 0; i < resgatadoTracker.Count; i++)
        {
            if (resgatadoTracker[quadrantes[i]].Contains(resgatado))
            {
                resgatadosNum++;
                resgatadoTracker[quadrantes[i]].Remove(resgatado);
                Destroy(resgatado);
            }
        }
    }

    private int quantidadeItensSpawn()
    {
        int num = 0;

        for (int i = 0; i < resgatadosNum; i++)
        {
            if (Random.Range(1, 2) % 2 == 0)
            {
                num++;
            }
        }
        
        return num == 0 ? 1 : num;
    }
}

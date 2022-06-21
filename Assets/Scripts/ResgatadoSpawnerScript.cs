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

    private Dictionary<GameObject, List<int>> resgatadoTracker = new Dictionary<GameObject, List<int>>();

    private Vector3[] aux;

    public int updateLevel = 4;

    public int offSetTempoVida = 1;

    public  int resgatadosNum = 1;

    private int idSeq = 0;

    private int getNextSeq()
    {
        return idSeq++;
    }

// Start is called before the first frame update
    void Start()
    {
        foreach (GameObject element in quadrantes)
        {
                resgatadoTracker.Add(element.gameObject, new List<int>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        var myEnum = resgatadoTracker.GetEnumerator();
        while (myEnum.MoveNext())
        {
            if (myEnum.Current.Value.Count < quantidadeRegatados)
            {
                myEnum.Current.Value.Add(spawnResgatado(myEnum.Current.Key));
            }
                
        }

    }

    // ReSharper disable Unity.PerformanceAnalysis
    int spawnResgatado(GameObject plane)
    {
        GameObject res = GameObject.Instantiate(resgatado, this.transform, false);

        
        //seta o id
        var id = getNextSeq();
        res.GetComponent<ResgatadoScript>().id = id;
        
        //Seta os itens
        res.GetComponent<ResgatadoScript>().agua = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().machado = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().erva = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().corda = quantidadeItensSpawn();
        res.GetComponent<ResgatadoScript>().vida = vidaSpawn();


        aux = plane.GetComponent<VerticeCollector>().vertices;
        res.transform.position = plane.transform.TransformPoint(aux[Random.Range(0,aux.Length-1)]) + new Vector3(0,0,0);

        updateQuantidadeResgatados();

        return id;
    }

    private float vidaSpawn()
    {
        return Random.Range(90 - (resgatadosNum * offSetTempoVida), 90);;
    }

    private void updateQuantidadeResgatados()
    {
        if (resgatadosNum % updateLevel == 0)
        {
            quantidadeRegatados = resgatadosNum / updateLevel;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void removerResgatado(GameObject resgatado, bool aumentarContador)
    {
        var myEnum = resgatadoTracker.GetEnumerator();
        while (myEnum.MoveNext())
        {
            if (myEnum.Current.Value.Contains(resgatado.GetComponent<ResgatadoScript>().id))
            {
                myEnum.Current.Value.Remove(resgatado.GetComponent<ResgatadoScript>().id);
                Destroy(resgatado);
                if (aumentarContador)
                {
                    resgatadosNum++;    
                }
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResgatadoScript : MonoBehaviour
{

    public int machado;
    public int erva;
    public int corda;
    public int agua;
    public float vida = 0;

    public int id;
    
    public Color cor;
    
    private void Start()
    {
        cor = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f));

        machado = Random.Range(0, 2);
        erva = Random.Range(0, 2);
        corda = Random.Range(0, 2);
        agua = Random.Range(0, 2);

        ParticleSystem.MainModule psMain = GetComponentInChildren<ParticleSystem>().main;
        psMain.startColor = new ParticleSystem.MinMaxGradient(cor, cor);
    }

    // Update is called once per frame
    void Update()
    {
        vida -= Time.deltaTime;
        if(vida < 0)
        {
            GetComponentInParent<ResgatadoSpawnerScript>().removerResgatado(this.gameObject,false);
        }
    }

    void Setup(int machado,int erva, int corda, int agua,float vida,int id){
        this.machado = machado;
        this.erva = erva;
        this.corda = corda;
        this.agua = agua;
        this.vida = vida;
        this.id = id;
    }
}

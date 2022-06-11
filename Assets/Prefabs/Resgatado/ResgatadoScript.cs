using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResgatadoScript : MonoBehaviour
{

    public int machado = 0;
    public int erva = 0;
    public int corda = 0;
    public int agua = 0;
    public float vida = 0;
    
    
    public Color cor;
    
    private void Start()
    {
        cor = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f));

        ParticleSystem.MainModule psMain = GetComponentInChildren<ParticleSystem>().main;
        psMain.startColor = new ParticleSystem.MinMaxGradient(cor, cor);
    }

    // Update is called once per frame
    void Update()
    {
        vida -= Time.deltaTime;
        if(vida < 0)
        {
            this.GetComponentInParent<ResgatadoSpawnerScript>().removerResgatado(this.gameObject);
        }
    }

    void Setup(int machado,int erva, int corda, int agua,float vida){
        this.machado = machado;
        this.erva = erva;
        this.corda = corda;
        this.agua = agua;
        this.vida = vida;
    }
}

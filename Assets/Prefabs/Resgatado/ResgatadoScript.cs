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


    public Color cor;

    private void Start()
    {
        cor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));

        machado = Random.Range(0, 1);
        erva = Random.Range(0, 1);
        corda = Random.Range(0, 1);
        agua = Random.Range(0, 1);

        ParticleSystem.MainModule psMain = GetComponentInChildren<ParticleSystem>().main;
        psMain.startColor = new ParticleSystem.MinMaxGradient(cor, cor);
    }

    // Update is called once per frame
    void Update()
    {
        vida -= Time.deltaTime;
        if (vida < 0)
        {
            this.GetComponentInParent<ResgatadoSpawnerScript>().removerResgatado(this.gameObject);
        }
    }

    void Setup(int machado, int erva, int corda, int agua, float vida)
    {
        this.machado = machado;
        this.erva = erva;
        this.corda = corda;
        this.agua = agua;
        this.vida = vida;
    }
}
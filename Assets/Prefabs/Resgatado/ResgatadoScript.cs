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
    public int knife;
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
        knife = Random.Range(0, 2);

        if (machado + erva + corda + knife == 0)
        {
            erva = 1;
        }

        ParticleSystem.MainModule psMain = GetComponentInChildren<ParticleSystem>().main;
        psMain.startColor = new ParticleSystem.MinMaxGradient(cor, cor);
    }

    // Update is called once per frame
    void Update()
    {
        vida -= Time.deltaTime;
        if (vida < 0)
        {
            GetComponentInParent<ResgatadoSpawnerScript>().removerResgatado(this.gameObject, false);
        }
    }

    void Setup(int machado, int erva, int corda, int knife, float vida, int id)
    {
        this.machado = machado;
        this.erva = erva;
        this.corda = corda;
        this.knife = knife;
        this.vida = vida;
        this.id = id;
    }
}

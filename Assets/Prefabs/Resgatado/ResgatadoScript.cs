using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResgatadoScript : MonoBehaviour
{

    public int machado = 0;
    public int erva = 0;
    public int corda = 0;
    public int agua = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup(int machado,int erva, int corda, int agua){
        this.machado = machado;
        this.erva = erva;
        this.corda = corda;
        this.agua = agua;
    }
}

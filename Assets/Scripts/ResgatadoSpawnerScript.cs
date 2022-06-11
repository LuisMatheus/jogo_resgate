using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResgatadoSpawnerScript : MonoBehaviour
{

    public GameObject resgatado;

    public List<GameObject> quadrantes;

    public int quantidade_regatados;

    private List<GameObject> resgatados = new List<GameObject>();
    private Dictionary<GameObject, int> resgatadoTracker = new Dictionary<GameObject, int>();

    public Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject element in quadrantes)
        {
                    
                resgatadoTracker.Add(element.gameObject, 0);
                var meshFilter = element.gameObject.GetComponent<MeshFilter>();
                var mesh = meshFilter.mesh;
                vertices = mesh.vertices;
            
                 
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < resgatadoTracker.Count; i++)
        {
            var item = resgatadoTracker.ElementAt(i);
             if (item.Value < quantidade_regatados)
            {

                spawnResgatado(quadrantes[i]);
                resgatadoTracker[item.Key] = resgatadoTracker[item.Key] +1;
            }      
        }
      

        
    }

    void spawnResgatado(GameObject plane)
    {
        GameObject res = GameObject.Instantiate(resgatado);

        //Seta os itens
        res.GetComponent<ResgatadoScript>().agua = 1;
        res.GetComponent<ResgatadoScript>().machado = 1;
        res.GetComponent<ResgatadoScript>().erva = 1;
        res.GetComponent<ResgatadoScript>().corda = 1;

        res.transform.SetParent(this.transform,false);
        res.transform.position = plane.transform.TransformPoint(vertices[Random.Range(0,vertices.Length-1)]);
        res.transform.position = res.transform.position + new Vector3(0,1,0);

    }

}

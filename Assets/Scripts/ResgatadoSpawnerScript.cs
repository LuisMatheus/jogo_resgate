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

    public Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject element in quadrantes)
        {
            foreach (Transform child in element.GetComponentsInChildren<Transform>())
        {
            if(child.gameObject.activeSelf && !GameObject.ReferenceEquals( element, child.gameObject)){
                resgatadoTracker.Add(child.gameObject, 0);
                var meshFilter = child.gameObject.GetComponent<MeshFilter>();
                var mesh = meshFilter.mesh;
                vertices = mesh.vertices;
                Debug.Log(vertices.Length);
            }
        }            
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
        res.transform.position = vertices[Random.Range(0,vertices.Length-1)];
        

    }

}

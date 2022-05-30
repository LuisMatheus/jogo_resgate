using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnB : MonoBehaviour
{
     public int qtd;
    public GameObject objectB;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BSpawn());
    }

    IEnumerator BSpawn()
    {
        int count = 0;
        while (count < qtd)
        {
            int spawnPointX = Random.Range(10, 50);
            
            int spawnPointZ = Random.Range(1, 44);

            Instantiate(objectB, new Vector3(spawnPointX, 6f, spawnPointZ), Quaternion.identity);

            yield return new WaitForSeconds(1f);
            count += 1;

        }

    }

}

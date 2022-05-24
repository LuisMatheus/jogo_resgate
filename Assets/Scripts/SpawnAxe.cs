using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAxe : MonoBehaviour

    

{

    public int qtd;
    public GameObject theAxe;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(axeSpawn());
    }

    IEnumerator axeSpawn()
    {
        int count = 0;
        while (count < qtd)
        {
            int spawnPointX = Random.Range(11, 50);
            
            int spawnPointZ = Random.Range(-3, -48);

            Instantiate(theAxe, new Vector3(spawnPointX, 4f, spawnPointZ), Quaternion.identity);

            yield return new WaitForSeconds(1f);
            count += 1;

        }

    }

}

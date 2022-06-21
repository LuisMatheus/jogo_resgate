using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHerb : MonoBehaviour
{
     public GameObject herb;
    private int qtdHerb;
    BoxCollider m;
    private int pos = 0;
    Vector3[] positionArray = new [] {new Vector3(-20.41368f, 0.6533f , 39.70f ),  new Vector3(-40.64f, 0.6533f , 19.5f), new Vector3(-2.3f, 0.6533f , 9.4f), new Vector3(-2.3f, 0.6533f , 48.93f), new Vector3(-19.1f, 0.6533f , 17.9f)};


    void Start(){
         herb.tag = "herb";
          herb.transform.GetChild(0).tag = "herb";
        
        m = herb.GetComponent<BoxCollider>();
        m.size = new Vector3(2.0f, 4.0f, 1f);

      
       
         
    }

    private void Update(){
        if(ShouldSpawn()){
            Spawn();
        }
    }
   
    private void Spawn()
    {
            
                if(pos > 4){
                    pos = 0;
                }
                Instantiate(herb, positionArray[pos] , Quaternion.identity);
                pos++;
                


                     
         
    }

    private bool ShouldSpawn(){
          qtdHerb = GameObject.FindGameObjectsWithTag("herb").Length;
       
       if(qtdHerb < 4){
        
        return true;
       }
       return false;

    }
}

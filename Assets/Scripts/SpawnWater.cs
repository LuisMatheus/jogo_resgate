using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
      public GameObject water;
    private int qtdWater;
   
    private int pos = 0;
    Vector3[] positionArray = new [] {new Vector3(-0.7f, 1.075f , 1.72f),  
    new Vector3(-45.1f, 0.4899763f , 3.203064f), 
    new Vector3(-45.1f, 0.5f , -44.1f), 
    new Vector3(-9.3f, 0.5f , -44.1f),
     new Vector3(-14.15f, -2.24f , -16.24f),
     new Vector3(13.61f, 4.66f , 18.11f),
     new Vector3(34.36f, 4.02f , 27.31f),
     new Vector3(34.36f, 3.9f , -17.5f),
     new Vector3(34.5f, 0.7f , -43.8f),
     new Vector3(3.9f, 0.8f , -17.5f)};


    void Start(){
         water.tag = "water";
        
        

      
       
         
    }

    private void Update(){
        if(ShouldSpawn()){
            Spawn();
        }
    }
   
    private void Spawn()
    {
            
                if(pos > 9){
                    pos = 0;
                }
                Instantiate(water, positionArray[pos] , Quaternion.identity);
                pos++;
                


                     
         
    }

    private bool ShouldSpawn(){
          qtdWater = GameObject.FindGameObjectsWithTag("water").Length;
       
       if(qtdWater < 8){
        
        return true;
       }
       return false;

    }
}

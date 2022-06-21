using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAxe : MonoBehaviour

    

{

   
    public GameObject axe;
    private int qtdAxe;
    BoxCollider m;
    private int pos = 0;
    Vector3[] positionArray = new [] {new Vector3(41.58f, 1.54f , -38.823f),  new Vector3(42.17f, 3.37f , -20.29f), new Vector3(21.33f, 2.62f , -34.94f), new Vector3(28.38f, 1.8f , -9.53f), new Vector3(14.3f, 1.39f , -9.53f)};


    void Start(){
         axe.tag = "axe";
        m = axe.GetComponent<BoxCollider>();
        m.size = new Vector3(2.0f, 2.0f, 1f);

      
       
         
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
                Instantiate(axe, positionArray[pos] , Quaternion.identity);
                pos++;
                


                     
         
    }

    private bool ShouldSpawn(){
          qtdAxe = GameObject.FindGameObjectsWithTag("axe").Length;
       
       if(qtdAxe < 3){
        
        return true;
       }
       return false;

    }

    

   

 
   

}

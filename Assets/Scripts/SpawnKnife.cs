using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour
{
    
    public GameObject knife;
    private int qtdKnife;
    BoxCollider m;
    private int pos = 0;
    Vector3[] positionArray = new [] {new Vector3(-9.547971f, 0.4767881f , -7.941479f),  new Vector3(-43.43f, 0.48f , -7.94f), new Vector3(-19f, -4.65f , -18.72f), new Vector3(-2.78f, 0.49f , -46.59f), new Vector3(-36.18f, -1.88f , -35.86f)};


    void Start(){
         knife.tag = "knife";
        m = knife.GetComponent<BoxCollider>();
        knife.transform.localScale = new Vector3(1.3883f, 1.3883f, 1.8883f);
 
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
                Instantiate(knife, positionArray[pos] , Quaternion.identity);
                pos++;
                


                     
         
    }

    private bool ShouldSpawn(){
          qtdKnife = GameObject.FindGameObjectsWithTag("knife").Length;
       
       if(qtdKnife < 3){
        
        return true;
       }
       return false;

    }
}

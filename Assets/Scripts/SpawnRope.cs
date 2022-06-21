using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRope : MonoBehaviour
{
    
    public GameObject rope;
    private int qtdRope;
    BoxCollider m;
    private int pos = 0;
    Vector3[] positionArray = new [] {new Vector3(24.5442f, 4.84f , 13.25f ),  new Vector3(25.5442f, 4.84f , 35.55f), new Vector3(43.93f, 1.5f , 35.55f), new Vector3(43.93f, 1.5f , 15.39f), new Vector3(5.1f, 1.26f , 41.29f)};


    void Start(){
         rope.tag = "rope";
         rope.transform.localScale = new Vector3(0.44601f, 0.5358166f, 0.40929f);
         rope.AddComponent<BoxCollider>();
        m = rope.GetComponent<BoxCollider>();
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
                Instantiate(rope, positionArray[pos] , Quaternion.identity);
                pos++;
                


                     
         
    }

    private bool ShouldSpawn(){
          qtdRope = GameObject.FindGameObjectsWithTag("rope").Length;
       
       if(qtdRope < 4){
        
        return true;
       }
       return false;

    }

}

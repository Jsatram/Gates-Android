using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTitleScreen : MonoBehaviour
{ 
    private float dir = Random.Range(0,100);
    void Start(){

    }
    void Update()
    {

        Vector3 pos = gameObject.transform.position;

        
        if(pos.x >= 275){
            dir -= 50;
        }

        if(pos.x <= -275){
            dir += 50;
        }


        if(dir >= 50){
            pos.x += 10;
        }
        else{
            pos.x -= 10;
        }

        gameObject.transform.position = pos;

        

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public bool dead = false;

    void Start(){
        dead = false;
    }

 
    // Update is called once per frame
    void Update()
    {   
        Vector3 yPos = transform.position;
        yPos.y = -40;
        transform.position = yPos;

        if(Input.touchCount > 0 && dead == false){

            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began){
                if(touch.position.x > 540){
                    moveRight();
                }
                else if(touch.position.x < 540){
                    moveLeft();
                }
                else{
                }
            }
            
        }
        else if (dead == true){
            Destroy(gameObject);
        }
        else{
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        dead = true;
    }

    void moveRight(){
        Vector3 pos = transform.position;

        if(pos.x < 40){
            
            pos.x = pos.x + 20;
            transform.position = pos;
            
        }
       
    }

    void moveLeft(){
        Vector3 pos = transform.position;

        if(pos.x > -40){
            
            pos.x = pos.x - 20;
            transform.position = pos;
            
        }
       
    }
}

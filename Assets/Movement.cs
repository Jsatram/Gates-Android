using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
      // Start is called before the first frame update
    public bool dead = false;

    public GameObject arrowR;
    public GameObject arrowL;
    public GameObject textR;
    public GameObject textL;

    public int startYPos;
    private float vel = 15;
    private bool objectOFF = false;

    private int distMid = 440;

    void Start(){
        dead = false;
    }

 
    // Update is called once per frame
    void Update()
    {   

        if(dead == false){
            Vector3 yPos = transform.position;
            yPos.y = startYPos;
            transform.position = yPos;

            if(Input.touchCount > 0){

                Touch touch = Input.GetTouch(0);
            

                if(touch.position.x > distMid){
                    moveRight();
                    arrowR.SetActive(false);
                    textR.SetActive(false);
                }
                else if(touch.position.x < distMid){
                    moveLeft();
                    arrowL.SetActive(false);
                    textL.SetActive(false);                    
                }
                else{
                    vel = 0;
                }

            
            }
            
         
        }
        else{

            if(objectOFF == false){
                gameObject.SetActive(false);
                objectOFF = true;
            }
            
        }
        
    }

    public void setColorPlayer(Color color){
        SpriteRenderer playerRend = gameObject.GetComponent<SpriteRenderer>();
        LineRenderer lineRend =  gameObject.GetComponent<LineRenderer>();

        
        playerRend.color = color;
        lineRend.SetColors(color,color);
    }

    void OnTriggerEnter2D(Collider2D other){
        dead = true;
    }

    void moveRight(){
        Vector3 pos = transform.position;

        if(pos.x < distMid){
            
            pos.x = pos.x + vel;
            transform.position = pos;
            
        }
       
    }

    void moveLeft(){
        Vector3 pos = transform.position;

        if(pos.x > -distMid){
            
            pos.x = pos.x - vel;
            transform.position = pos;
            
        }
       
    }
}

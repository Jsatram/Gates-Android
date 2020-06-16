using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
     // Start is called before the first frame update

    public float downSpeed;
    public float sideSpeed;
    private float downStart = 8;
    private float sideStart = 5;

    public GameObject levelObj;
    private int dir; 
    private int level;
    private bool pass = false;

    private int distMid = 290;
    private float minSideSpeed = 0f;
    private float maxSideSpeed;
    void Start()
    {
        Vector3 temp = transform.position;
        

        level = levelObj.GetComponent<Level>().level;
        maxSideSpeed = sideStart * (1f + ((level-1f)/10f));

        calculateMinSideSpeed();


        sideSpeed = Random.Range(minSideSpeed,maxSideSpeed);

        temp.x = Random.Range(-340,340);
        transform.position = temp;

        dir = Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        level = levelObj.GetComponent<Level>().level;
        


        if(pass == false && transform.position.y < -300){
            levelObj.GetComponent<Level>().passGate();
            pass = true;
        } //-300 is players y value

        accel();
        move();

        if(transform.position.y < -2100){
            Destroy(gameObject);
        }
    }

    void accel(){

        downSpeed = downStart * (1f + ((level-1f)/10f));
        

        if(downSpeed >= 15){
            downSpeed = 15;
        }
        if(sideSpeed >= 10){
            sideSpeed = 10;
        }



    }   

    void move(){
        Vector3 temp = transform.position;

        if(dir >= 50 && transform.position.x < distMid){
            temp.x += sideSpeed;
        }
        else if(dir < 50 && transform.position.x > -distMid){
            temp.x -= sideSpeed;
        }
        else if(transform.position.x >= distMid){
            temp.x -= sideSpeed;
            dir = dir - 50;
        }
        else if(transform.position.x <= -distMid){
            temp.x += sideSpeed;
            dir = dir + 50;
        }

        temp.y -= downSpeed;

        transform.position = temp;

    }

    void calculateMinSideSpeed(){
        minSideSpeed = 1f * (1f + (level - 1f)/10f);

        if(minSideSpeed >= maxSideSpeed){
            minSideSpeed = maxSideSpeed;
        }

    }
}

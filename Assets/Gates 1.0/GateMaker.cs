using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMaker : MonoBehaviour
{
    public GameObject square;

    public Player player;

    public Score score;
    public int frame;
    public int freq;
    public int scale;
    public int gatestillNext;

    public int currlvl;
    public int nxtlvlcount;

    public int choice;
    public int prevSpace;

    public int max;
    void Start()
    {   
        max = 6;
        makeGate(transform.position);
        freq = 0;
        scale = 200;
        nxtlvlcount = 0;
        gatestillNext = 4;
        currlvl = 1;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 posPointer = transform.position;
        

        if(freq == scale){

            if(player.dead == false && gatestillNext > 0){
                makeGate(posPointer);
            }
            else if(player.dead == false && gatestillNext == 0){
                betweenlvl(posPointer);
            }

            if(freq >= scale){
                freq= 0;
                
                if(scale > 60){
                    scale = scale - 5;
                }
                else{
                    scale = 60;
                }
            }
            

            
        }
        freq++;
    }

    void makeGate(Vector3 posPointer){
        


        while(true){

            choice = Random.Range(1,max-1);
            if(choice != prevSpace){
                break;
            }

        }
        

        for(int i = 0; i <= max; i++){
            if(i != choice){

                Instantiate(square, posPointer, Quaternion.identity);
                posPointer.x = posPointer.x + 20;             
            }
            else{
                posPointer.x = posPointer.x + 20;   
            }

        }
        posPointer.x = -60;
        transform.position = posPointer;
        gatestillNext--;
        

        prevSpace = choice;
    }

    void betweenlvl(Vector3 posPointer){
        
        if(nxtlvlcount == 0){
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 120;
            Instantiate(square, posPointer, Quaternion.identity);
            nxtlvlcount++;

        }
        else if(nxtlvlcount == 1){
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 20;
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 80;
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 20;
            Instantiate(square, posPointer, Quaternion.identity);
            nxtlvlcount++;

        }
        else{
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 20;
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 20;
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 40;
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 20;
            Instantiate(square, posPointer, Quaternion.identity);
            posPointer.x = posPointer.x + 20;
            Instantiate(square, posPointer, Quaternion.identity);

            nxtlvlcount = 0;
            score.score++;
            currlvl++;
            gatestillNext = gatestillNext + (5 * (currlvl));
            
            

        }
        
    }

}

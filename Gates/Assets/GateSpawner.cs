using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GateSpawner : MonoBehaviour
{
    public GameObject levelObj;
    public GameObject gate;
    public float timer;
    public float timeout;

    public int numSpawned = 0; //NOTE THIS IS # SPAWNED IN CURRENT LEVEL
    public int tillNext = 5;
    public int levelGrowth = 5;
    public int currlevel = 1;

    private float spawnAcc = 0.80f; //this is an increase of 20% not 80% 

    private SpriteRenderer left;
    private SpriteRenderer right;

    void Start()
    {
        timer = 0;
        timeout = 3;
        
    }

    void Update()
    {
       
        spawnGate();
    }

    void spawnGate(){
        timer += Time.deltaTime;
        if (timer > timeout && levelObj.GetComponent<Level>().gameOver == false) {
            timer -= timeout;
            GameObject newGate = Instantiate(gate, transform.position, Quaternion.identity);
            newGate.SetActive(true);

            left = newGate.transform.GetChild(0).GetComponent<SpriteRenderer>();
            left.color = levelObj.GetComponent<Level>().currentGateColor;
            right = newGate.transform.GetChild(1).GetComponent<SpriteRenderer>();
            right.color = levelObj.GetComponent<Level>().currentGateColor;

            // Debug.Log(levelObj.GetComponent<Level>().color);
            // Debug.Log(Color.green);
            numSpawned++;

            if(numSpawned == tillNext){
                
                
                levelObj.GetComponent<Level>().spawnerLevelForColor();

                currlevel++;
                numSpawned = 0;
                tillNext = levelGrowth * currlevel;
                timeout = timeout * spawnAcc;

                if(timeout <= 1){
                    timeout = .75f;
                }
            }
        }   
    }
}

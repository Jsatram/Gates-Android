using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update

    public int level;
    public bool gameOver = false;
    public GateSpawner spawner;
    public Movement player;
    

    public int gatesLeft;
    public int counter;

    public int gatesTillNext; //more accurate way to track number of gates in level
    private int gatesPerLevel;

    private float timer;
    private float timeout;

    
    private Color[] gateColor;
    private Color[] playerColor;
    private int numberofColors = 10;
    private int currentColorIndex = 0;
    private int currentPlayerColorIndex = 0; 
    public Color currentGateColor;
    public Color currentPlayerColor;
    public float duration = 1f;

    void Start(){
        gateColor = new Color[numberofColors];
        playerColor = new Color[numberofColors];
        gateColor[0] = new Color(0f, .43f, 1f);
        gateColor[1] = new Color(.01f,.81f,1f);
        gateColor[2] = new Color(0f,1f,.65f); 
        gateColor[3] = new Color(.08f,1f,0f); 
        gateColor[4] = new Color(.93f,1f,0f);
        gateColor[5] = new Color(1f,.56f, 0f);
        gateColor[6] = new Color(1f,.19f, .01f);
        gateColor[7] = new Color(1f, 0f, .35f); 
        gateColor[8] = new Color(.91f, 0f, 1f); 
        gateColor[9] = new Color(.06f, 0f, 1f);   

        playerColor[0] = new Color(1f,.56f, 0f);
        playerColor[1] = new Color(1f,.19f, .01f);
        playerColor[2] = new Color(1f, 0f, .35f); 
        playerColor[3] = new Color(.91f, 0f, 1f); 
        playerColor[4] = new Color(.06f, 0f, 1f);   
        playerColor[5] = new Color(0f, .43f, 1f);
        playerColor[6] = new Color(.01f,.81f,1f);
        playerColor[7] = new Color(0f,1f,.65f); 
        playerColor[8] = new Color(.08f,1f,0f); 
        playerColor[9] = new Color(.93f,1f,0f);


        timer = 0;
        timeout = 4;
        gatesPerLevel = 5;
        gatesLeft = gatesTillNext = gatesPerLevel;
        level = 1;
        counter = 0;
    }
    void Update()
    {

        setPlayerPrefs();

        gameOver = player.GetComponent<Movement>().dead;

        if(gameOver == true){
            timer += Time.deltaTime;
            if (timer > timeout) {
                SceneManager.LoadScene("GameOver");
            } 
        }

        colorize();


        
    }

    public void spawnerLevelForColor(){
        currentColorIndex++;
    }

    void colorize(){

        if(currentColorIndex >= numberofColors){
            currentColorIndex = 0;
        }
        if(currentPlayerColorIndex >= numberofColors){
            currentPlayerColorIndex = 0;
        }

        currentGateColor = gateColor[currentColorIndex];
        currentPlayerColor = playerColor[currentPlayerColorIndex];
        
        player.setColorPlayer(currentPlayerColor);
    }
    public void passGate(){
        
        if(gameOver == false){
            counter++;

            if(counter == gatesPerLevel * level){
                gatesTillNext+=gatesPerLevel;
                currentPlayerColorIndex++;
                level++;
                counter = 0;
        }   

        
            gatesLeft = gatesTillNext - counter;
        }
        

        

    }


    void setPlayerPrefs(){

        if(gameOver == true && level > PlayerPrefs.GetInt("HighScore") && level > 0){
            PlayerPrefs.SetInt("HighScore", level);
        }
        else{
            PlayerPrefs.SetInt("PreviousRun",level);
        }
    }

}

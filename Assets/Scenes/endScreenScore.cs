using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endScreenScore : MonoBehaviour
{    
    private TextMeshProUGUI text;

    void Start(){
        text  = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if(PlayerPrefs.HasKey("HighScore") == true){
            text.SetText(PlayerPrefs.GetInt("HighScore").ToString());
        }
        else{
            text.SetText("0");
        }
        
    }
}

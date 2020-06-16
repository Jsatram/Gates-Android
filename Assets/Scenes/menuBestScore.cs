using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class menuBestScore : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start(){
        text  = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if(PlayerPrefs.HasKey("HighScore") == true){
            text.SetText("BEST " + PlayerPrefs.GetInt("HighScore").ToString());
        }
        else{
            text.SetText("BEST 0");
        }
        
    }
}

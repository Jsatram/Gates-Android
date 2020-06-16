using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endScreenLastRun : MonoBehaviour
{
     private TextMeshProUGUI text;

    void Start(){
        text  = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.SetText(PlayerPrefs.GetInt("PreviousRun").ToString());
    }
}

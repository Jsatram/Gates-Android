using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GatesText : MonoBehaviour
{
    public Level level;

    private TextMeshProUGUI text;

    void Start(){
        text  = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.SetText("GATES: " + level.GetComponent<Level>().gatesLeft.ToString());
    }
}

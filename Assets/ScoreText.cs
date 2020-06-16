using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public Level level;

    private TextMeshProUGUI text;

    void Start(){
        text  = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.SetText(level.GetComponent<Level>().level.ToString());
    }
}

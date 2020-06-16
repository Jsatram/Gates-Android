using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public TextMeshProUGUI text;    
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();

        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        text.SetText(score.ToString());
    }
}

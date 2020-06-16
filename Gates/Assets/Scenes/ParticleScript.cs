using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject levelObj;

    public Color staticColor;
    private Vector3 pos;

    private SpriteRenderer color;
    private float vel;

    public float width;
    public float height;

    void Start()
    {
        pos.x = Random.Range(-540,540);
        pos.y = 1100;

        
        color = gameObject.GetComponent<SpriteRenderer>();
        LineRenderer lineRend =  gameObject.GetComponent<LineRenderer>();
        gameObject.transform.localScale = new Vector3(width,height,1);

        if(levelObj != null){
            vel = Random.Range(2, 10 + (5 * (1f + ((levelObj.GetComponent<Level>().level-1f)/10f))));
            color.color = levelObj.GetComponent<Level>().currentPlayerColor;
            lineRend.SetColors(levelObj.GetComponent<Level>().currentPlayerColor,levelObj.GetComponent<Level>().currentPlayerColor);
        }
        else{
            vel = Random.Range(2,5);
            color.color = staticColor;
            lineRend.SetColors(staticColor,staticColor);
        }

        


        
    }

    // Update is called once per frame
    void Update()
    {
        pos.y -= vel;

        if(pos.y <= -2100){
            Destroy(gameObject);
        }

        transform.position = pos;

                
    }
}

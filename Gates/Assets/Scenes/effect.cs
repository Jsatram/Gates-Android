using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject particle;

    private float timer = 0f;
    private float limit = .5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer >= limit)
        {
 
            GameObject newPart = Instantiate(particle, transform.position, Quaternion.identity);
            newPart.SetActive(true);

            timer = 0f;
        }

        

    }
}

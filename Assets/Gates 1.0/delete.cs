﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -110){
            Destroy(gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    void Start(){
    }
    void Update()
    {
        moveDown();
    }

    void moveDown(){
        Vector3 pos= transform.position;
        pos.y = pos.y - 1;
        transform.position = pos;
    }


}

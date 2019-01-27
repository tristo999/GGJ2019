using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropThrough : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = gameObject.GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Vertical") < 0){
            coll.isTrigger = true;
        } 
        else{
            coll.isTrigger = false;
        }
    }

}

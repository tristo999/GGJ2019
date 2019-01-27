using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideChecker : MonoBehaviour
{
    public bool currentlyHiding;
    // Start is called before the first frame update
    void Start()
    {
        currentlyHiding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Front")
        {
            currentlyHiding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Front")
        {
            currentlyHiding = false;
        }
    }
}

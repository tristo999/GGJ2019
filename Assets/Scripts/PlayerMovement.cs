using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 1f;
    public float jumpForce = 1f;
    public Rigidbody2D rb;
    public bool jump = false;
    public GameObject topLeft;
    public GameObject bottomRight;
    public bool noHorz;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jump = true;
        noHorz = false;
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        float vert = Input.GetAxis("Vertical");

        if (vert > .8f && rb.velocity.y == 0)
        {
            jump = Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position);
            if (jump) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        float horz = Input.GetAxis("Horizontal");
        if (noHorz)
        {
            if (horz >= 0)
            {
                transform.position = new Vector3(transform.position.x + horz * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x + horz * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

}


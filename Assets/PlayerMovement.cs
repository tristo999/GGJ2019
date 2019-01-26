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
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jump = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");

        if (vert > .8f && rb.velocity.y == 0)
        {
            jump = Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position);
            if (jump) {
                Debug.Log("JUMP");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        float horz = Input.GetAxis("Horizontal");
        //rb.MovePosition(new Vector2(transform.position.x + transform.position.x *  horz * playerSpeed, transform.position.z));
        transform.position = new Vector3(transform.position.x + horz * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        Debug.Log(horz);
    }

}


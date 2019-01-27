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
    public bool hiding;
    public GameObject leftHiding;
    public GameObject rightHiding;
    public GameObject masterObject;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jump = true;
        noHorz = false;
        hiding = false;
        masterObject = GameObject.FindGameObjectWithTag("GameController");
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        if (!dead)
        {
            float vert = Input.GetAxis("Vertical");

            if (vert > .8f && rb.velocity.y == 0)
            {
                jump = Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position);
                if (jump)
                {
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
            if (leftHiding.GetComponent<HideChecker>().currentlyHiding && rightHiding.GetComponent<HideChecker>().currentlyHiding)
            {
                hiding = true;
            }
            else
            {
                hiding = false;
            }
            if (hiding)
            {
                Physics2D.IgnoreLayerCollision(9, 10, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(9, 10, false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(9, 10, true);
            masterObject.GetComponent<PauseGame>().killPlayer();
            dead = true;
        }
    }

}


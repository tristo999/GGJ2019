using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool direction = true;
    public float walkSpeed = 1f;
    public float runSpeed = 2f;
    public Rigidbody2D rb;
    public GameObject topLeft;
    public GameObject bottomRight;
    public LayerMask groundLayer = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction)
        {
            transform.position = new Vector3(transform.position.x + walkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x - walkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (!Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position, groundLayer))
        {
            direction = !direction;
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
        }
    }
}

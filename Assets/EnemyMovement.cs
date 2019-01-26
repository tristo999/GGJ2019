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
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        if (!Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position))
        {
            direction = !direction;
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            direction = !direction;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool direction = true;
    public float walkSpeed = 1f;
    public float runSpeed = 2f;
    public Rigidbody2D rb;
    public GameObject topLeft;
    public GameObject bottomRight;
    public LayerMask groundLayer = 3;
    public PolygonCollider2D wallCheck;
    public enum EnemyState { Walking, Chasing };
    public EnemyState currentState;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        currentState = EnemyState.Walking;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {   if (currentState == EnemyState.Walking)
        {
            if (direction)
            {
                transform.position = new Vector3(transform.position.x + walkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - walkSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (!Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position, groundLayer))
            {
                direction = !direction;
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
            }
        } else if (currentState == EnemyState.Chasing)
        {
            
            if (Physics2D.OverlapArea(topLeft.transform.position, bottomRight.transform.position, groundLayer))
            {
                float dir = AngleDir(transform.forward, (player.transform.position - transform.position), transform.up);
                if (!direction)
                {
                    dir *= -1;
                }
                transform.position = new Vector3(transform.position.x + dir * runSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                if (dir == 1)
                {
                    if (!direction)
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
                    }
                    direction = true;
                } else if (dir == -1)
                {
                    if (direction)
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
                    }
                    direction = false;
                }
            }
        }
    }

    public void changeDirection()
    {
        direction = !direction;
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0));
    }

    public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }


}

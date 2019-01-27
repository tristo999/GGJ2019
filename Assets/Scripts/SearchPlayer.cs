using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerMovement>().hiding)
            {
                this.gameObject.GetComponentInParent<EnemyMovement>().currentState = EnemyMovement.EnemyState.Chasing;
            }
            else
            {
                this.gameObject.GetComponentInParent<EnemyMovement>().currentState = EnemyMovement.EnemyState.Walking;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerMovement>().hiding)
            {
                this.gameObject.GetComponentInParent<EnemyMovement>().currentState = EnemyMovement.EnemyState.Chasing;
            }
            else
            {
                this.gameObject.GetComponentInParent<EnemyMovement>().currentState = EnemyMovement.EnemyState.Walking;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<EnemyMovement>().currentState = EnemyMovement.EnemyState.Walking;
        }
    }
}

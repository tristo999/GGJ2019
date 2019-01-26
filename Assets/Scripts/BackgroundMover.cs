using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public GameObject background;
    public GameObject backDrop;
    public float backgroundSpeed = .2f;
    public float backDropSpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        background.transform.position = new Vector3(background.transform.position.x + horz * backgroundSpeed * Time.deltaTime, background.transform.position.y, background.transform.position.z);
        backDrop.transform.position = new Vector3(backDrop.transform.position.x + horz * backDropSpeed * Time.deltaTime, backDrop.transform.position.y, backDrop.transform.position.z);
    }
}

using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1MCC : MonoBehaviour
{
    public GameObject legs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 5;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.localPosition += new Vector3(verticalInput, 0, -horizontalInput) * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            legs.GetComponent<Animation>().Play("Walking");
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            legs.GetComponent<Animation>().Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(new Vector3(default, 90, default));
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(default, 90, default));
        }
    }
}
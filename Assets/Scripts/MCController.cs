
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCController : MonoBehaviour
{
    bool isInWall = false, isJumping = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            isInWall = true;
        }    
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            isInWall = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        float moveSpeed = 5;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (!isInWall)
        {
            transform.localPosition += new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
           GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
           bullet.gameObject.transform.position += transform.position + new Vector3(0, 0, 1);
           bullet.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
           bullet.AddComponent<Rigidbody>();
           bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && !isJumping)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }
}
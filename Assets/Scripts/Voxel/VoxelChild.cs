using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
        tag = "voxelItem";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag != "ground" &&
            collision.transform.gameObject.tag != "voxelItem")
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.transform.gameObject.tag == "ground" &&
            other.transform.gameObject.tag == "voxelItem")
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

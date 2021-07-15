using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        Transform[] childVoxels = GetComponentsInChildren<Transform>();
        foreach (var item in childVoxels)
            item.transform.gameObject.AddComponent<VoxelChild>();
        Destroy(GetComponent<VoxelChild>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
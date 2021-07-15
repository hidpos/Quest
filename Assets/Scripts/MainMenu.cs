using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0.01f, 0));
    }
}

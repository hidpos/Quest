using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act1 : MonoBehaviour
{
    // credits
    public Image blackScreen;
    public GameObject creditsObjs;
    public GameObject cameraCredits;
    bool endOfCredits = false;
    // main
    public GameObject act1Objs;

    // Start is called before the first frame update
    void Start()
    {
        StopAllCoroutines();
        StartCoroutine(CreditsCutscene());
    }
    IEnumerator CreditsCutscene()
    {
        cameraCredits.GetComponent<Animation>().Play("CameraCredits");
        yield return new WaitForSeconds(26);
        blackScreen.GetComponent<Animation>().Play("BlackScreen");
        yield return new WaitForSeconds(3);
        creditsObjs.SetActive(false);
        act1Objs.SetActive(true);
        endOfCredits = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (endOfCredits)
        {
            
        }
    }
}
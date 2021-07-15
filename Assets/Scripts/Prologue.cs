using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    public GameObject MC, Per2, cloudSpeechNPC, cloudSpeechMC;
    public AudioClip alert;
    public Text Qoutes;
    public bool endOfPrologue = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(titleAppear(1));
        StartCoroutine(StartDialogue(5));
    }
    IEnumerator titleAppear(int sec)
    {
        yield return new WaitForSeconds(sec);
        
        GetComponent<AudioSource>().clip = alert;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(3);
        Image[] childs = GetComponentsInChildren<Image>();
        foreach (var child in childs)
        {
            if (child.gameObject.name == "BlackScreen")
            {
                child.GetComponent<Animation>().Play();
            }
        }
    }
    IEnumerator StartDialogue(int sec) {
        yield return new WaitForSeconds(sec);
        DialogueSystem[] system = Resources.FindObjectsOfTypeAll<DialogueSystem>();
        system[0].gameObject.SetActive(true);
        StartCoroutine(system[0].SetDialogue(MC, Per2, Qoutes.text, cloudSpeechNPC, cloudSpeechMC));
    }
    // Update is called once per frame
    void Update()
    {
        DialogueSystem[] system = Resources.FindObjectsOfTypeAll<DialogueSystem>();
        if (system[0].i == 27)
        {
            GetComponent<Animation>().Play("MainAnimation");
            Per2.GetComponent<Animation>().enabled = false;
        }
        if (endOfPrologue)
        {
            StartCoroutine(NextAct());
        }
    }
    IEnumerator NextAct()
    {
        DialogueSystem[] system = Resources.FindObjectsOfTypeAll<DialogueSystem>();
        
        Image[] childs = GetComponentsInChildren<Image>();
        foreach (var child in childs)
        {
            if (child.gameObject.name == "BlackScreen")
            {
                child.GetComponent<Image>().color += new Color(default, default, default, 0.01f);
            }
            if (child.GetComponent<Image>().color.a >= 1)
            {
                system[0].gameObject.SetActive(false);
                Act1[] act1 = Resources.FindObjectsOfTypeAll<Act1>();
                act1[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(3);
                gameObject.SetActive(false);      
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text DName;
    public Text DText;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public IEnumerator SetDialogue(GameObject per1, GameObject per2,
                            string text, GameObject cloudSpeech1, GameObject cloudSpeech2) {
        string[] quotes = text.Split('#');
        int j = 1; int k = 1;
        for (i = 0; i < quotes.Length; i++)
        {
            string[] content = quotes[i].Split('/');
            string prevName = DName.text;
            DName.text = content[0];
            DText.text = content[1];
            if (DName.text != "Джонсон" && DName.text != "Johnson")
            {
                if (DName.text != prevName)
                {
                    cloudSpeech1.GetComponent<Animation>().Play("SpeechCloud");
                }
                j++;
                if (j % 2 == 0)
                    per2.GetComponent<Animation>().Play("DialogueIdle");
            }
            if (DName.text == "Джонсон" || DName.text == "Johnson")
            {
                if (DName.text != prevName)
                {
                    cloudSpeech2.GetComponent<Animation>().Play();
                }
                k++;
                if (k % 10 == 0)
                    per1.GetComponent<Animation>().Play("DialogueIdle");
            }
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => Input.anyKeyDown);
        }
        Prologue[] prologue = Resources.FindObjectsOfTypeAll<Prologue>();
        prologue[0].endOfPrologue = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
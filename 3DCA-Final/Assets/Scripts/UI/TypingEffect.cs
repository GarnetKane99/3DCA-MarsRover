using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    // Code used from https://unitycoder.com/blog/2015/12/03/ui-text-typewriter-effect-script/

    Text txt;
    string storedText;  

    void Awake()
    {
        txt = GetComponent<Text>();
        storedText = txt.text;
        txt.text = "";

        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach(char c in storedText)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }
}

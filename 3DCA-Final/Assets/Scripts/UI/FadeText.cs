using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(FadeTextIn(1f, GetComponent<Text>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeTextIn(float t, Text txt)
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0);
        while (txt.color.a < 1.0f)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextOut(float t, Text txt)
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);
        while (txt.color.a > 0.0f)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene5Script : MonoBehaviour
{
    public Transform CamSpot;

    float Timer;

    public Image Overlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > 1.5f)
        {
            Camera CamPos = GetComponent<Camera>();

            CamPos.transform.position = Vector3.Lerp(transform.position, CamSpot.position, 0.0005f);
        }

        if(Timer > 11.0f)
        {
            Overlay.gameObject.SetActive(true);

            Overlay.color = Color.Lerp(Overlay.color, new Color(0, 0, 0, 1), 0.01f);
        }

        if (Timer > 15.0f)
            SceneManager.LoadScene("JakeScene");
    }
}

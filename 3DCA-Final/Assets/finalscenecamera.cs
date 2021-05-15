using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalscenecamera : MonoBehaviour
{
    float Timer = 0.0f;
    public Transform target, ogspot, target2;
    public Transform newPos;

    public Transform Spot1, Spot2;

    public Image Overlay;

    public GameObject Oppy1, Persy1;

    public GameObject Credits;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer <= 6.0f)
        {
            transform.position = ogspot.position;
        }
        if(Timer > 6.0f && Timer < 13.0f)
        {
            var TargetRot = Quaternion.LookRotation(target.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 0.0075f);
            transform.position = newPos.position;
        }

        if(Timer > 12.0f)
        {
            Overlay.color = Color.Lerp(Overlay.color, new Color(0, 0, 0, 1), 0.05f);
        }
        if(Timer > 15.5f)
        {
            Oppy1.SetActive(true);
            Persy1.SetActive(true);
        }

        if(Timer > 16.0f && Timer < 20.0f)
        {
            transform.position = Spot1.position;
            transform.rotation = Spot1.rotation;
            Overlay.color = new Color(0, 0, 0, 0);
            Overlay.gameObject.SetActive(false);
        }

        if(Timer >= 20.0f && Timer < 23.0f)
        {
            Spot1.parent = null;
        }

        if(Timer >= 23.0f)
        {
            var TargetRot = Quaternion.LookRotation(target2.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 0.0075f);
        }

        if(Timer > 27.0f)
        {
            Overlay.gameObject.SetActive(true);
            Overlay.color = Color.Lerp(Overlay.color, new Color(0, 0, 0, 1), 0.1f);
        }

        if(Timer > 28.5f)
        {
            Credits.gameObject.SetActive(true);
        }


        if(Timer > 31.0f)
        {
            SceneManager.LoadScene("MainMenu");
            ExperienceType Experience = FindObjectOfType<ExperienceType>();
            Experience.Interactive = false;
            Experience.Cinematic = false;
        }
    }
}

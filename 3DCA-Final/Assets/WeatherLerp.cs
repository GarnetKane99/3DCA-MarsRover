using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherLerp : MonoBehaviour
{
    float MaxChangeTimer = 0.0f;
    public Light SandBrightness;
    bool ColourChange1 = false, ColourChange2 = false;

    public Camera Cam;

    public Image Overlay;

    public GameObject Persy, Persy2, Persy3;

    public Transform Change1, Change2, Change3;

    public GameObject IntroText;

    //Vector3 Colour1 = 1, 0.9f, 0.75f

    // Start is called before the first frame update
    void Start()
    {
        StartColour();
        //Cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxChangeTimer += Time.deltaTime;

        if (MaxChangeTimer < 5)
        {
            if (ColourChange1)
                StartColour();
            if (ColourChange2)
                ResetColour();
        }

        Overlay.color = Color.Lerp(Overlay.color, new Color(0, 0, 0, 0), 0.0085f);


        if(MaxChangeTimer > 9.5f && MaxChangeTimer <= 13.0f)
        {
            Persy.SetActive(true);
            var Rotation = Quaternion.Euler(-10.0f, 20.0f, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 0.0085f);
        }

        if(MaxChangeTimer > 13.0f && MaxChangeTimer <= 18.0f)
        {
            Destroy(IntroText);
            transform.position = Change1.position;
            transform.rotation = Change1.gameObject.transform.rotation;
        }

        if(MaxChangeTimer > 17.5f)
        {
            Persy2.SetActive(true);
            Persy2.GetComponentInChildren<perseverance>().collision = true;
            Persy2.GetComponentInChildren<perseverance>().newVector = true;
        }

        if(MaxChangeTimer > 18.0f && MaxChangeTimer <= 23.0f)
        {
            transform.position = Change2.position;
            transform.rotation = Change2.gameObject.transform.rotation;
        }

        if (MaxChangeTimer > 22.5f)
            Persy3.SetActive(true);

        if(MaxChangeTimer > 23)
        {
            transform.position = Change3.position;
            transform.rotation = Change3.gameObject.transform.rotation;
        }

    }

    void StartColour()
    {
        if (MaxChangeTimer < 4.0f)
        {
            ColourChange1 = true;
            ColourChange2 = false;
            SandBrightness.color = Color.Lerp(SandBrightness.color, new Color(0.3f, 0.3f, 0.3f), 0.005f);
            Invoke("ResetColour", 1.2f);

            Cam.backgroundColor = Color.Lerp(Cam.backgroundColor, new Color(0, 0, 0), 0.005f);
        }
    }

    void ResetColour()
    {
        if (MaxChangeTimer < 4.0f)
        {
            ColourChange1 = false;
            ColourChange2 = true;
            SandBrightness.color = Color.Lerp(SandBrightness.color, new Color(1, 0.9f, 0.75f), 0.005f);
            Invoke("StartColour", 1.2f);

            Cam.backgroundColor = Color.Lerp(Cam.backgroundColor, new Color(0.6f, 0.5f, 0.3f), 0.005f);
        }
    }
}

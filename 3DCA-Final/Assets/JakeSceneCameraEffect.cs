using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeSceneCameraEffect : MonoBehaviour
{
    public Camera mainCam;
    public Transform CameraSwap;
    float maxRotateTime = 5.0f;
    float maxLookTime = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (maxRotateTime > 0)
        {
            maxRotateTime -= Time.deltaTime;
            mainCam.transform.Rotate(0, -5 * Time.deltaTime, 0, Space.World);
        }

        if(maxLookTime > 0)
        {
            maxLookTime -= Time.deltaTime;
        }
        if(maxLookTime <= 0)
        {
            mainCam.transform.position = CameraSwap.position;
            //mainCam.transform.rotation = Quaternion.Euler(-1.5f, -90f, 0);
            mainCam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

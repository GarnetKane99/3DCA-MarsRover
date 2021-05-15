using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5Script : MonoBehaviour
{
    public Transform CamSpot;

    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > 2.5f)
        {
            Camera CamPos = GetComponent<Camera>();

            CamPos.transform.position = Vector3.Lerp(transform.position, CamSpot.position, 0.0005f);
        }
    }
}

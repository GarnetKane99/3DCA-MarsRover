using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Script : MonoBehaviour
{
    float moveTimer = 0.0f;
    public Light OppyLight;
    public Light FloorLight;

    Camera mainCam;

    public Transform OppyFace;

    public Canvas OppyHUD;

    //audio of oppy looking down

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer > 2.0f && moveTimer < 3.0f)
        {
            mainCam.transform.position = OppyFace.position;
            mainCam.transform.rotation = OppyFace.rotation;
            OppyHUD.gameObject.SetActive(true);
        }

        if (moveTimer >= 3.0f && moveTimer < 3.5f)
        {
            transform.Rotate(1.0f * Time.deltaTime, 0, 0);
        }
        if(moveTimer >= 3.5f && moveTimer < 4.0f)
        {
            //FloorLight.gameObject.SetActive(true);
        }
        if(moveTimer >= 4.5f && moveTimer < 6.5f)
        {
            transform.Rotate(8.0f * Time.deltaTime, 0, 0);
        }
        if(moveTimer >= 7.5f)
        {
            FloorLight.gameObject.SetActive(true);
        }

    }
}

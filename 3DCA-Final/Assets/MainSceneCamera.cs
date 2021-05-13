using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneCamera : MonoBehaviour
{
    float rotSpeed = 7.0f;
    bool StopRotate = false;
    public Transform newLoc;
    float WaitTimer = 0.0f;
    Camera mainCam;
    public GameObject TextHolder;
    float otherTimer = 0.0f;

    //AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        // Sound.volume = 175.0f;
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.x >= 0.0f)
        {
            StopRotate = true;
            WaitTimer += Time.deltaTime;
        }
        otherTimer += Time.deltaTime;
        if(otherTimer > 0.5f)
        {
            TextHolder.SetActive(true);
        }

        if(WaitTimer > 3.0f)
        {
            mainCam.transform.position = newLoc.transform.position;
            TextHolder.SetActive(false);
        }

        if (WaitTimer > 8.0f)
            SceneManager.LoadScene("Scene4");

        if (!StopRotate)
            Rotate();
    }

    void Rotate()
    {
        transform.Rotate(rotSpeed * Time.deltaTime, 0, 0);
    }
}

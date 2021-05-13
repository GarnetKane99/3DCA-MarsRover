using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RotateInPlace : MonoBehaviour
{
    public float rotSpeed = 50;
    public Image Overlay;
    float firstDelay = 0;
    float Delay = 0;
    public GameObject TextStuff;
    Vector2 StartingPos;

    bool StopRotate = false;

    float changeTimer = 0.0f;

    void Update()
    {
        firstDelay += Time.deltaTime / 2;
        if(firstDelay >= 1.0f)
        {
            firstDelay = 1.0f;
            Delay += Time.deltaTime;
        }
/*        Delay += Time.deltaTime / 3.0f;*/

        //if (Delay < 3.0f)
        //{

            Overlay.color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), Delay / 3);
        //}

        if(Delay >= 3.0f && changeTimer <= 1.0f)
        {
            TextStuff.SetActive(true);
        }



        if(StartingPos == null)
        {
            StartingPos = new Vector2(transform.rotation.x, transform.rotation.y);
        }

        Vector2 CurrentPos = new Vector2(transform.rotation.x, transform.rotation.y);
        //Debug.Log(CurrentPos.y);

        if(CurrentPos.y <= 0)
        {
            //Debug.Log("LoadScene");
            StopRotate = true;
        }

        if (StopRotate)
            changeTimer += Time.deltaTime;

        if (changeTimer > 1.0f)
            TextStuff.SetActive(false);

        if (changeTimer >= 2.0f)
            SceneManager.LoadScene("SkyScene");

        if (!StopRotate)
            Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
    }
}

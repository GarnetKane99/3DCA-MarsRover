using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerController : MonoBehaviour
{
    public Text spdTxt;
    public Image spdImg;

    bool isGainingSpeed = false;
    bool isDroppingSpeed = false;
    bool isCurrentlyGaining = false;

    int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            isGainingSpeed = true;
        }
        if (Input.GetKeyUp("w"))
        {
            isGainingSpeed = false;
        }

        if(isGainingSpeed && !isCurrentlyGaining)
        {
            StartCoroutine(GainSpeed());
        }

        if (!isGainingSpeed && !isDroppingSpeed)
        {
            StartCoroutine(DropSpeed());
        }

        speed = Mathf.Clamp(speed, 0, 20);
        spdTxt.text = speed.ToString();
        //spdImg.fillAmount = (speed * 5) / 100;
        spdImg.fillAmount = 1;
    }

    IEnumerator DropSpeed()
    {
        isDroppingSpeed = true;
        speed -= 1;
        yield return new WaitForSeconds(1f);
        isDroppingSpeed = false;
    }

    IEnumerator GainSpeed()
    {
        isCurrentlyGaining = true;
        speed += 1;
        yield return new WaitForSeconds(0.5f);
        isCurrentlyGaining = false;
    }
}

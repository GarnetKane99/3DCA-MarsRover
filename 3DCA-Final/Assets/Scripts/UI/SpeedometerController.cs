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
    float speedFillAmount;
    public float lerpSpeed;
    int speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        speedFillAmount = 0;
        speedModifier = 1;
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
        if (Input.GetKeyDown("s"))
        {
            speedModifier = 2;
        }
        if (Input.GetKeyUp("s"))
        {
            speedModifier = 1;
        }

        if (isGainingSpeed && !isCurrentlyGaining)
        {
            StartCoroutine(GainSpeed());
        }

        if (!isGainingSpeed && !isDroppingSpeed)
        {
            StartCoroutine(DropSpeed());
        }

        speed = Mathf.Clamp(speed, 0, 20);
        spdTxt.text = speed.ToString();
        speedFillAmount = ((speed * 5f)/100f);
        spdImg.fillAmount = Mathf.Lerp(spdImg.fillAmount, speedFillAmount, lerpSpeed * Time.deltaTime);
    }

    IEnumerator DropSpeed()
    {
        isDroppingSpeed = true;
        speed -= 1 * speedModifier;
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

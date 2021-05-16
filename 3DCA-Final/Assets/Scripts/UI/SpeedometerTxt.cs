using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerTxt : MonoBehaviour
{
    private Text speedometerTxt;
    float speedometerValue;

    // Start is called before the first frame update
    void Start()
    {
        speedometerTxt = GetComponent<Text>();
        StartCoroutine(Speedometer());   
    }

    // Update is called once per frame
    void Update()
    {
        speedometerTxt.text = "0" + speedometerValue.ToString();
    }

    IEnumerator Speedometer()
    {
        for(int i = 0; i < 4; i++)
        {
            speedometerValue = Random.Range(3, 5);
            yield return new WaitForSeconds(0.5f);
        }
        speedometerValue = 1;
        yield return new WaitForSeconds(1f);
        speedometerValue = 0;

    }
}

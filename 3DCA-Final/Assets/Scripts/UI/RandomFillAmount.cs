using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFillAmount : MonoBehaviour
{
    private Image fillTarget;
    public float minAmount;
    public float maxAmount;

    public float fillDelay;
    private bool isRunning;
    private float fillValue;

    private float lerpSpeed;

    void Start()
    {
        fillTarget = gameObject.GetComponent<Image>();
        lerpSpeed = 1f * Time.deltaTime;
    }

    void Update()
    {
        if (!isRunning)
            StartCoroutine(RandomValue());

        BarFiller();
    }

    void BarFiller()
    {
        fillTarget.fillAmount = Mathf.Lerp(fillTarget.fillAmount, fillValue, lerpSpeed);
    }

    IEnumerator RandomValue()
    {
        isRunning = true;
        fillValue = Random.Range(minAmount, maxAmount);
        yield return new WaitForSeconds(fillDelay);
        isRunning = false;
    }

}

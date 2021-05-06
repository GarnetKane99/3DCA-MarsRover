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

    void Start()
    {
        fillTarget = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (!isRunning)
            StartCoroutine(RandomFill());

    }

    IEnumerator RandomFill()
    {
        isRunning = true;
        float fillValue = Random.Range(minAmount, maxAmount);
        fillTarget.fillAmount = fillValue;
        yield return new WaitForSeconds(fillDelay);
        isRunning = false;
    }
}

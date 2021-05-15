using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetActive();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActive()
    {
        this.gameObject.SetActive(true);
        Invoke("DisableActive", 0.5f);
    }

    void DisableActive()
    {
        this.gameObject.SetActive(false);
        Invoke("SetActive", 0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Audio2 : MonoBehaviour
{
    float finalTimer = 0.0f;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FinalScene")
        {
            finalTimer += Time.deltaTime;

            Debug.Log(finalTimer);
            if(finalTimer > 27.0f)
            {
                AudioSource Audi = GetComponent<AudioSource>();
                float currentVol = Audi.volume;

                Audi.volume = Mathf.Lerp(currentVol, 0.0f, 0.018f);
            }

            if (finalTimer >= 29.5f)
            {
                Destroy(this);
            }
        }
    }
}

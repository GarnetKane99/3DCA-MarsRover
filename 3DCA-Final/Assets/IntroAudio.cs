using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            AudioSource thisAudio = GetComponent<AudioSource>();
            float currentVol = thisAudio.volume;
            thisAudio.volume = Mathf.Lerp(currentVol, 0.75f, 0.05f);
        }

        if(SceneManager.GetActiveScene().name == "MissionControlScene")
        {
            AudioSource Audi = GetComponent<AudioSource>();

            timer += Time.deltaTime;

            if(timer >= 13.0f)
            {
                float currentVol = Audi.volume;

                Audi.volume = Mathf.Lerp(currentVol, 0.0f, 0.01f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractiveSceneChange : MonoBehaviour
{
    bool TimerStart = false;
    float Timer = 0.0f;

    public Image Overlay;

    float MaxTimer = 20.0f;

    public Text MaxTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxTime.text = MaxTimer.ToString();
        MaxTimer -= Time.deltaTime;

        if(TimerStart)
        {
            Timer += Time.deltaTime;
        }

        if(Timer > 1.0f || MaxTimer < 3.0f)
        {
            Overlay.color = Color.Lerp(Overlay.color, new Color(0, 0, 0, 1), 0.05f);
        }

        if(Timer > 3.0f || MaxTimer <= 0.0f)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TimerStart = true;
        }
    }
}

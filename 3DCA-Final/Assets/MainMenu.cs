using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cinematic()
    {
        GameObject ExperienceType = GameObject.FindGameObjectWithTag("Experience");
        ExperienceType.GetComponent<ExperienceType>().Cinematic = true;
        SceneManager.LoadScene("TitleScreen");
    }

    public void Interactive()
    {
        GameObject ExperienceType = GameObject.FindGameObjectWithTag("Experience");
        ExperienceType.GetComponent<ExperienceType>().Interactive = true;
        SceneManager.LoadScene("TitleScreen");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

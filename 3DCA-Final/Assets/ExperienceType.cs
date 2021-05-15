using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceType : MonoBehaviour
{
    public bool Cinematic = false;
    public bool Interactive = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

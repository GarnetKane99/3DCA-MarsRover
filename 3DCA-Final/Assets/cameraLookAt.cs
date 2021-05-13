using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cameraLookAt : MonoBehaviour

{
    Animator CamAnim;
    float transitiondelay = 0.0f;
    float speed = 0;
    public Transform target;
    bool TargetFound = false;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        CamAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transitiondelay += Time.deltaTime;
        //transform.LookAt(target);

        //transform.rotation = transform.LookAt(target);


        //if(!TargetFound)
        // {
        //TargetFound = true;
        //}
        Timer += Time.deltaTime;

        if(target)
        //var TargetR = Quaternion.LookRotation(target.position - transform.position);

        if (transitiondelay > 1.0f)
        {
            speed += Time.deltaTime / 3.0f;
        }

        if (speed > 0)
        {
            var TargetRot = Quaternion.LookRotation(target.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 0.0001f);
        }


        if (transitiondelay > 5.0f)
        {
            CamAnim.enabled = true;
        }

        if(Timer > 22.75f)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

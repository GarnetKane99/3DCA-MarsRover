using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersyScan : MonoBehaviour
{
    float Timer = 0.0f;
    public GameObject Arm1, Arm2, Arm3;

    public Light LightObject;

    public Transform LSpot1, LSpot2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 2.0f && Timer <= 7.5f)
        {
            var Arm1Rot = Quaternion.Euler(0, 0, 90);

            Arm1.transform.rotation = Quaternion.Slerp(Arm1.transform.rotation, Arm1Rot, 0.0075f);

            var Arm2Rot = Quaternion.Euler(0, 0, -100);

            Arm2.transform.rotation = Quaternion.Slerp(Arm2.transform.rotation, Arm2Rot, 0.0075f);
        }

        if (Timer > 7.5f && Timer < 8.0f)
        {
            LightObject.gameObject.SetActive(true);
            //Arm3.transform.rotation = Quaternion.Slerp(Arm3.transform.rotation, Arm3Rot, 0.0075f);
        }

        if (Timer >= 8.0f && Timer < 11.0f)
        {
            //Arm3.transform.Rotate(0, 90, -20);
            //Arm3.transform.rotation = Quaternion.Slerp(Arm3.transform.rotation, Quaternion.Euler(-20, 0, 0), 0.05f);
            //LightObject.transform.position = Vector3.Lerp(LightObject.transform.position, LSpot1.position, 0.0085f);

            //var TargetRot = Quaternion.LookRotation(LSpot2.gameObject.transform.position - transform.position);

            //Arm3.transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 0.0085f);


            LightObject.transform.position = Vector3.Lerp(LightObject.transform.position, LSpot1.position, 0.0085f);

            //Quaternion LookSpot = LightObject.gameObject.transform.position;
            Quaternion LookSpot = Quaternion.LookRotation(LightObject.gameObject.transform.position - Arm3.transform.position);

            if (LookSpot != null)
                Arm3.transform.rotation = Quaternion.RotateTowards(Arm3.transform.rotation, LookSpot, 0.02f);


        }

        if (Timer >= 11.0f && Timer < 13.0f)
        {
            LightObject.transform.position = Vector3.Lerp(LightObject.transform.position, LSpot2.position, 0.005f);

            Quaternion LookSpot = Quaternion.LookRotation(LightObject.gameObject.transform.position - Arm3.transform.position);

            if (LookSpot != null)
                Arm3.transform.rotation = Quaternion.RotateTowards(Arm3.transform.rotation, LookSpot, 0.02f);
        }

        if(Timer >= 13.0f)
        {
            GameObject ExperienceType = GameObject.FindGameObjectWithTag("Experience");
            if(ExperienceType.GetComponent<ExperienceType>().Cinematic)
            {

            }
            else if (ExperienceType.GetComponent<ExperienceType>().Interactive)
                SceneManager.LoadScene("PerssyScene");
        }
    }
}

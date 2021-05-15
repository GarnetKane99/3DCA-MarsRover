using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene4Script : MonoBehaviour
{
    float moveTimer = 0.0f;
    public Light OppyLight;
    public Light FloorLight;
    public Transform Light1Spot, Light2Spot;
    public GameObject ShadowForRotate;

    Camera mainCam;

    public Transform OppyFace;

    public Canvas OppyHUD;

    public AudioSource PowerDown;
    public AudioSource CuriousSound;

    public GameObject Battery;

    //audio of oppy looking down

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    bool hasSpawned = false;

    // Update is called once per frame
    void Update()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer > 2.0f && moveTimer < 3.0f)
        {
            mainCam.transform.position = OppyFace.position;
            mainCam.transform.rotation = OppyFace.rotation;
            OppyHUD.gameObject.SetActive(true);
        }

        if (moveTimer >= 3.0f && moveTimer < 3.5f)
        {
            transform.Rotate(1.0f * Time.deltaTime, 0, 0);
        }
        if(moveTimer >= 3.5f && moveTimer < 4.0f)
        {
            //FloorLight.gameObject.SetActive(true);
        }
        if(moveTimer >= 4.5f && moveTimer < 6.5f)
        {
            transform.Rotate(8.0f * Time.deltaTime, 0, 0);
        }
        if(moveTimer >= 7.5f && moveTimer < 8.5f)
        {
            FloorLight.gameObject.SetActive(true);

            var TargetRot = Quaternion.LookRotation(FloorLight.gameObject.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 0.05f);

        }

        if(moveTimer >= 8.5f && moveTimer < 11.0f)
        {
            FloorLight.transform.position = Vector3.Lerp(FloorLight.transform.position, Light1Spot.position, 0.0085f);

            var TargetRot = Quaternion.LookRotation(FloorLight.gameObject.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, 0.0085f);
            //ShadowForRotate.transform.rotation.z = Quaternion.Euler(0, 0, -20);
            var Shadow = Quaternion.Euler(-90, 0, -30);
            ShadowForRotate.transform.rotation = Quaternion.Slerp(ShadowForRotate.transform.rotation, Shadow, 0.0085f);
        }

        if(moveTimer >= 11.0f && moveTimer < 15.0f)
        {
            FloorLight.transform.position = Vector3.Lerp(FloorLight.transform.position, Light2Spot.position, 0.0085f);

            var newTarget = Quaternion.LookRotation(FloorLight.gameObject.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, newTarget, 0.0085f);
            var Shadow = Quaternion.Euler(-90, 0, 15);
            ShadowForRotate.transform.rotation = Quaternion.Slerp(ShadowForRotate.transform.rotation, Shadow, 0.0085f);
        }

        if (moveTimer > 15.0f && moveTimer <= 18.0f)
        {
            float newIntensity = 0.0f;
            FloorLight.intensity = Mathf.Lerp(FloorLight.intensity, newIntensity, 0.05f);
        }

        if(moveTimer > 18.0f && !hasSpawned)
        {
            hasSpawned = true;
            Battery.SetActive(true);
            //SceneManager.LoadScene("MissionControlScene");
        }

        if(moveTimer > 20.5f && moveTimer <= 25.0f)
        {
            var NewTarget = Quaternion.Euler(45, 21.85f, -0.2f);
            transform.rotation = Quaternion.Slerp(transform.rotation, NewTarget, 0.0085f);
            var shadowTarget = Quaternion.Euler(-74.5f, 0, 15);
            ShadowForRotate.transform.rotation = Quaternion.Slerp(ShadowForRotate.transform.rotation, shadowTarget, 0.0085f);
        }

        if(moveTimer > 25.0f)
        {
            SceneManager.LoadScene("MissionControlScene");
        }
    }
}

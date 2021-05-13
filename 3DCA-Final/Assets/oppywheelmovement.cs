using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oppywheelmovement : MonoBehaviour
{
    public GameObject Wheels;
    public WheelCollider WC;

    // Start is called before the first frame update
    void Start()
    {
        WC = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion Rotation;// = WC.transform.rotation;
        Vector3 position;// = WC.transform.position;


        WC.GetWorldPose(out position, out Rotation);

        Wheels.transform.position = position;
        Wheels.transform.rotation = Rotation;
    }
}

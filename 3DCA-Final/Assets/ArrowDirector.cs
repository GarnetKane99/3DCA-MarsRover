using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirector : MonoBehaviour
{
    public GameObject Oppy;



    // Update is called once per frame
    void Update()
    {
        float zRot = Mathf.Atan2(Oppy.transform.position.y - transform.position.y, Oppy.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, zRot - 180, 90);

        Debug.Log(zRot);
    }
}

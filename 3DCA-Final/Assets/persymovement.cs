using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persymovement : MonoBehaviour
{
    // Start is called before the first frame update

    bool collision = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!collision)
            rb.velocity = Vector3.forward * 1.0f;
        else
            rb.velocity = Vector3.zero;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall1"))
        {
            collision = true;
            rb.velocity = Vector3.zero;
        }
    }
}

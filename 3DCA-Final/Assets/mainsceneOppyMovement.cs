using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainsceneOppyMovement : MonoBehaviour
{
    Rigidbody rb;

    bool collision = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!collision)
            rb.velocity = Vector3.forward * 0.5f;
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

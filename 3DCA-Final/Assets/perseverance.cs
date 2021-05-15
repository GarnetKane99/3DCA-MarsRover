using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseverance : MonoBehaviour
{
    Rigidbody rb;

    public bool collision = false;

    public bool newVector = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!newVector)
            rb.velocity = Vector3.right * 3.0f;

        if(newVector)
        {
            rb.velocity = Vector3.forward * 3.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall1"))
        {
            collision = true;
            rb.velocity = Vector3.zero;
        }
    }
}

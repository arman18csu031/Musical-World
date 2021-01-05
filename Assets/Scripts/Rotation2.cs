using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation2 : MonoBehaviour
{
    public float speedz;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddTorque(transform.forward * speedz);
    }
}

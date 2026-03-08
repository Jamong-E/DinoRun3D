using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDinoPosition : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        rb.velocity = Vector3.zero;
        Debug.Log("≈ª√‚");
    }
}

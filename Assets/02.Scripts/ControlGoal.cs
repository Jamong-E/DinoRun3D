using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGoal : MonoBehaviour
{
    GameObject Raptor;
    void Start()
    {
        Raptor = GameObject.Find("NewDino");
    }

    // Update is called once per frame
    void Update()
    {
        if (Raptor.transform.position.z > this.transform.position.z) { Debug.Log("GOAL!!!!!"); }
    }
}

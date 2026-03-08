using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDinoNew : MonoBehaviour
{
    float moveSpeed = 0.1f;
    float sideSpeed = 0.1f;
    float gapX = 2f;
    //public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, moveSpeed));
        if (Input.GetKey(KeyCode.A)) { transform.Translate(new Vector3(-1 * sideSpeed, 0, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(new Vector3(sideSpeed, 0, 0)); }

        //float detect = transform.childCount % 2 - 1;
        //float prev = detect / 2;
        //for (int i = 1; i <= transform.childCount; i++)
        //{
        //    transform.GetChild(i-1).position = new Vector3(prev, 0, 0);
        //    prev += ((i % 2) * 2 - 1) * i;
        //}

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = new Vector3(gapX * (i + 0.5f - (float)transform.childCount / 2), 0, 0);
        }
    }
}

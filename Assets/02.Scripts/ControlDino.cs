using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDino : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Raptor;
    float moveSpeed = 0.1f;
    float sideSpeed = 0.1f;
    //public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - Cam.transform.position;
        SetChildren(1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, moveSpeed));
        if (Input.GetKey(KeyCode.A)) { transform.Translate(new Vector3(-1 * sideSpeed, 0, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(new Vector3(sideSpeed, 0, 0)); }
        if (Input.GetKey(KeyCode.Alpha2)) { SetChildren(2); }
        if (Input.GetKey(KeyCode.Alpha3)) { SetChildren(3); }
        if (Input.GetKey(KeyCode.Alpha5)) { SetChildren(5); }
        //Cam.transform.position = transform.position - offset;
    }
    void SetChildren(int n)
    {
        for (int i = 0; i < transform.childCount; i++) { Destroy(transform.GetChild(i).gameObject); }
        for (int j = 0; j < n; j++) {
            GameObject NewDino = Instantiate(Raptor);
            NewDino.transform.SetParent(gameObject.transform);
            NewDino.transform.position = transform.position;
            if (j > 1)
            {
                NewDino.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f,10f), 0, Random.Range(-10f, 10f)));
            }
        }
    }
}

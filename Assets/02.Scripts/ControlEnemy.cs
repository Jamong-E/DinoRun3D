using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    enum State { Idle, Run }

    public GameObject Raptor;
    private float moveSpeed = 6;
    private float detectRadius = 8;
    private State state;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.Idle:
                DetectDino();
                break;
            case State.Run:
                GotoDino();
                break;
        }
    }

    private void DetectDino()
    {
        Vector3 vect = this.transform.position - Raptor.transform.position;
        if (Vector3.Distance(this.transform.position, Raptor.transform.position) < detectRadius)
        {
            state = State.Run;
            GetComponent<Animator>().speed = 1f;
        }
        
    }
    private void GotoDino()
    {
        if (Raptor == null) { return; }
        transform.LookAt(2 * this.transform.position - Raptor.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Raptor.transform.position, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(this.transform.position, Raptor.transform.position) < 0.1f) {
            Destroy(gameObject);
            Raptor.GetComponent<ControlDinoNew>().DinoCount -= 1;
        }
    }

}

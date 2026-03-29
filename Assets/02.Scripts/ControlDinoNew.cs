using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDinoNew : MonoBehaviour
{
    float moveSpeed = 3f;
    float sideSpeed = 3f;
    float radiusInitial = 0f;
    float radiusStep = 0.3f;
    float angleStep = 137.508f;    // Golden Angle
    public int DinoCount = 1;
    int DinoVisual;
    int MaxVisual = 20;
    public GameObject Raptors;
    public Transform Cam;
    public GameObject PrefabRaptor;
    public TextMeshPro CountUI;
    //public Vector3 offset;
    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
            if (Input.GetKey(KeyCode.A)) { transform.position = new Vector3(Mathf.Clamp(transform.position.x - sideSpeed * Time.deltaTime, -3.8f, 3.8f), transform.position.y, transform.position.z); }
            if (Input.GetKey(KeyCode.D)) { transform.position = new Vector3(Mathf.Clamp(transform.position.x + sideSpeed * Time.deltaTime, -3.8f, 3.8f), transform.position.y, transform.position.z); }

            /*for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).position = new Vector3(gapX * (i + 0.5f - (float)transform.childCount / 2), 0, 0);
            }*/
            CountUI.text = DinoCount + "";
            if (DinoCount > MaxVisual) { DinoVisual = MaxVisual; }
            else { DinoVisual = DinoCount; }
            if ((DinoVisual < MaxVisual || Raptors.transform.childCount < MaxVisual) && DinoVisual != Raptors.transform.childCount) { DinoCircle(); }
            // Billboarding :: 화면에서 각도 고정
            CountUI.transform.LookAt(CountUI.transform.position + Cam.rotation * Vector3.forward, Cam.rotation * Vector3.up);
        }
        
    }

    private void DinoCircle()
    {
        for (int i = Raptors.transform.childCount; i > 0; i--) { Destroy(Raptors.transform.GetChild(i-1).gameObject); }
        for (int i = 0; i < DinoVisual; i++)
        {
            GameObject Raptor = Instantiate(PrefabRaptor);
            float angle = i * angleStep;
            float radius = i * radiusStep + radiusInitial;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Raptor.transform.SetParent(Raptors.transform);
            Raptor.transform.localPosition = new Vector3(x, 0, z);
        }
        if (Raptors.transform.childCount == 1) { Raptors.transform.GetChild(0).localPosition = new Vector3(0, 0, 0); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDinoNew : MonoBehaviour
{
    float moveSpeed = 0.1f;
    float sideSpeed = 0.1f;
    float gapX = 2f;
    float radius = 1f;
    float ratio = 1.0f;
    public int DinoCount = 1;
    int DinoVisual;
    public GameObject Raptors;
    public GameObject PrefabRaptor;
    public TextMeshPro CountUI;
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

        /*for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = new Vector3(gapX * (i + 0.5f - (float)transform.childCount / 2), 0, 0);
        }*/
        CountUI.text = DinoCount + "";
        if (DinoCount > 10) { DinoVisual = 10; }
        else { DinoVisual = DinoCount; }
        if ((DinoVisual < 10 || Raptors.transform.childCount < 10) && DinoVisual != Raptors.transform.childCount) { DinoCircle(); }
    }

    private void DinoCircle()
    {
        float angleStep = 360f / (DinoVisual * ratio);
        for (int i = Raptors.transform.childCount; i > 0; i--) { Destroy(Raptors.transform.GetChild(i-1).gameObject); }
        for (int i = 0; i < DinoVisual; i++)
        {
            GameObject Raptor = Instantiate(PrefabRaptor);
            float angle = i * angleStep * Mathf.PI / 180;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Raptor.transform.SetParent(Raptors.transform);
            Raptor.transform.localPosition = new Vector3(x, 0, z);
        }
        if (Raptors.transform.childCount == 1) { Raptors.transform.GetChild(0).localPosition = new Vector3(0, 0, 0); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlEnemyRaptors : MonoBehaviour
{
    public TextMeshPro EnemyCountUI;

    public GameObject EnemyRaptorPrefab;
    public int EnemyRaptorCount;

    float radiusInitial = 0f;
    float radiusIncrement = 0.5f;
    float angleIncrement = 137.5f;


    // Start is called before the first frame update
    void Start()
    {
        EnemyGenerate();
    }

    void Update()
    {
        // UI is also a child, so 1 must be taken away
        int countCurrent = transform.childCount - 1;
        if (countCurrent < 1) { Destroy(gameObject); }
        EnemyCountUI.text = countCurrent + "";
    }

    void EnemyGenerate()
    {
        for (int i = 0; i < EnemyRaptorCount; i++)
        {
            float radiusCurrent = radiusInitial + i * radiusIncrement;
            float angle = i * angleIncrement;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radiusCurrent;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * radiusCurrent;

            GameObject EnemyRaptor = Instantiate(EnemyRaptorPrefab, transform);
            EnemyRaptor.transform.localPosition = new Vector3(x, 0, z);
        }
    }
}

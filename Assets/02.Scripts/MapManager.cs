using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] PrefabMaps;
    float currentZ = -5;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, PrefabMaps.Length);
            GameObject Map = Instantiate(PrefabMaps[index]);
            currentZ += Map.GetComponent<MapScript>().MapZ() / 2;    // To Sum Up Both Maps' Z length
            Map.transform.position = new Vector3(0, 0.1f*i, currentZ);
            currentZ += Map.GetComponent<MapScript>().MapZ() / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] PrefabMaps;
    public GameObject Goal;
    float currentZ = -5;
    // Start is called before the first frame update
    void Start()
    {
        Goal = GameObject.FindWithTag("Goal");
        CreateMap(5);
    }

    private void CreateMap(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject Map;
            if (i == 0) { Map = Instantiate(PrefabMaps[Random.Range(0, PrefabMaps.Length)]); }
            else { Map = Instantiate(PrefabMaps[Random.Range(0, PrefabMaps.Length)]); }
            currentZ += Map.GetComponent<MapScript>().MapZ() / 2;    // To Sum Up Both Maps' Z length
            Map.transform.position = new Vector3(0, 0.1f * i, currentZ);
            currentZ += Map.GetComponent<MapScript>().MapZ() / 2;
        }
        currentZ += Goal.GetComponent<MapScript>().MapZ() / 2;
        Goal.transform.position = new Vector3(0, 0, currentZ);
    }

    public float GoalDistance() { return Goal.transform.position.z; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public StageScriptableObject[] Stages;
    public GameObject Goal;
    float currentZ = -5;


    int currentStageIndex;

    void Start()
    {
        CreateStage();
    }

    private void CreateStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex %= Stages.Length;
        CreateMap(Stages[currentStageIndex]);
    }
    private void CreateMap(StageScriptableObject Stage)
    {
        GameObject Map;
        for (int i = 0; i < Stage.StageSize; i++)
        {
            if (i == 0) { Map = Instantiate(Stage.StageStart); }
            else if (i == Stage.StageSize - 1) { Map = Instantiate(Stage.StageGoal); Goal = Map; }
            else { Map = Instantiate(Stage.Maps[Random.Range(0, Stage.Maps.Length)]); }
            currentZ += Map.GetComponent<MapScript>().MapZ() / 2;
            Map.transform.position = new Vector3(0, 0.01f * i, currentZ);
            currentZ += Map.GetComponent<MapScript>().MapZ() / 2;
        }
    }

    private void Awake()
    {
        if (instance != null) { Destroy(this.gameObject); }     // Singleton
        else { instance = this; }
    }

    public int GetStage() { return PlayerPrefs.GetInt("Stage", 1); }

    public float GoalDistance() { return Goal.transform.position.z; }
}

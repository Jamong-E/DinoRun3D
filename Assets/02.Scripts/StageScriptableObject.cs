using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stage", menuName = "Stage Object/Stage", order = 0)]

public class StageScriptableObject : ScriptableObject
{
    public int StageSize;
    public GameObject StageStart;
    public GameObject StageGoal;
    public GameObject[] Maps;
}




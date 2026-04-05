using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGoal : MonoBehaviour
{
    GameObject Raptor;
    void Start()
    {
        Raptor = GameObject.Find("NewDino");
    }

    // Update is called once per frame
    void Update()
    {
        if (Raptor.transform.position.z > this.transform.position.z) {
            PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage", 1) + 1);
            SceneManager.LoadScene("GameScene");
        }
    }
}

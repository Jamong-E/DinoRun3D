using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart = false;
    public GameObject Raptor;
    public GameObject MapManager;
    public GameObject GamePanel;
    public GameObject TitlePanel;
    public Slider ProgressBar;

    void Update()
    {
        ProgressBar.value = Raptor.transform.position.z / MapManager.GetComponent<MapManager>().GoalDistance();
    }

    private void Awake()
    {
        if (instance != null) { Destroy(this.gameObject); }     // Singleton
        else { instance = this; }
    }

    public void GameStart()
    {
        Raptor.SetActive(true);
        GamePanel.SetActive(true);
        TitlePanel.SetActive(false);
        GameManager.instance.isGameStart = true;
    }
}

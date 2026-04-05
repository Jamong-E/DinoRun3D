using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart = false;
    public GameObject Raptor;
    public GameObject MapManagerObject;
    public GameObject GamePanel;
    public GameObject TitlePanel;
    public Slider ProgressBar;

    public TextMeshProUGUI NowStageText;
    public TextMeshProUGUI NextStageText;

    void Update()
    {
        ProgressBar.value = Raptor.transform.position.z / MapManagerObject.GetComponent<MapManager>().GoalDistance();
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
        NowStageText.text = MapManager.instance.GetStage().ToString();
        NextStageText.text = (MapManager.instance.GetStage() + 1).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart = false;
    public GameObject Raptor;
    public GameObject MapManagerObject;
    public GameObject PanelGame;
    public GameObject PanelTitle;
    public GameObject PanelClear;
    public GameObject PanelGameover;
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
        else {
            instance = this;
            PanelGame.SetActive(true);
            PanelTitle.SetActive(true);
            PanelClear.SetActive(false);
            PanelGameover.SetActive(false);
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        Raptor.SetActive(true);
        PanelGame.SetActive(true);
        PanelTitle.SetActive(false);
        PanelClear.SetActive(false);
        PanelGameover.SetActive(false);
        GameManager.instance.isGameStart = true;
        NowStageText.text = MapManager.instance.GetStage().ToString();
        NextStageText.text = (MapManager.instance.GetStage() + 1).ToString();
    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        GameManager.instance.isGameStart = false;
        PanelGame.SetActive(true);
        PanelTitle.SetActive(false);
        PanelClear.SetActive(true);
        PanelGameover.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameManager.instance.isGameStart = false;
        PanelGame.SetActive(true);
        PanelTitle.SetActive(false);
        PanelClear.SetActive(false);
        PanelGameover.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}

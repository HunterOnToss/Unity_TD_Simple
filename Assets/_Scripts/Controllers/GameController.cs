using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool GameIsOver;
    public GameObject GameOverUi;
    public string NextLevel = "Polygon";
    public int LevelToUnlock = 2;
    public SceneFader TdSceneFader;

    void Start()
    {
        GameIsOver = false;
    }

    void Update ()
    {
        if (GameIsOver) return;
        if (PlayerStats.Lives <= 0) { EndGame(); }
    }

    public void WinLevel()
    {
        Debug.Log("Win!");
        PlayerPrefs.SetInt("LevelReached", LevelToUnlock);
        TdSceneFader.FadeTo(NextLevel);
    }

    private void EndGame()
    {
        GameIsOver = true;
        GameOverUi.SetActive(true);
    }
}

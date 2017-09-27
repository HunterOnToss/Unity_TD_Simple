using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool GameIsOver;
    public GameObject GameOverUi;
    public SceneFader TdSceneFader;
    public GameObject CompleteLevelUI;

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
        GameIsOver = true;
        CompleteLevelUI.SetActive(true);
    }

    private void EndGame()
    {
        GameIsOver = true;
        GameOverUi.SetActive(true);
    }
}

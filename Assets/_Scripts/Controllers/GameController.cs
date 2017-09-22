using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool GameIsOver;
    public GameObject GameOverUi;

    void Start()
    {
        GameIsOver = false;
    }

    void Update ()
    {
        if (GameIsOver) return;
        if (PlayerStats.Lives <= 0) { EndGame(); }
    }

    private void EndGame()
    {
        GameIsOver = true;
        GameOverUi.SetActive(true);
    }
}

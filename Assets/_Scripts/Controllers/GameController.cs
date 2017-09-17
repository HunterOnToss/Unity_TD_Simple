using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject GameOverUI;

    void Start()
    {
        GameIsOver = false;
    }

    void Update ()
    {
        if (GameIsOver) return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0) { EndGame(); }
    }

    private void EndGame()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true);
    }
}

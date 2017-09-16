using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool _gameEnded = false;

	void Update ()
    {
        if (_gameEnded) return;
        if (PlayerStats.Lives <= 0) { EndGame(); }
    }

    private void EndGame()
    {
        _gameEnded = true;
        Debug.Log("Game over MAn!");
    }
}

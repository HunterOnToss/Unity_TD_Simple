using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text RoundsText;
    public SceneFader GameSceneFader;
    public string MenuSceneName = "MainMenu";

    public void Retry()
    {
        GameSceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        GameSceneFader.FadeTo(MenuSceneName);
    }

    private void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader TdSceneFader;
    public string MenuSceneName = "MainMenu";

    public string NextLevel = "Polygon";
    public int LevelToUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("LevelReached", LevelToUnlock);
        TdSceneFader.FadeTo(NextLevel);
    }

    public void Menu()
    {
        TdSceneFader.FadeTo(MenuSceneName);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader Fader;
    public Button[] LevelButtons;

    void Start()
    {
        var levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for (var i = 0; i < LevelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                var t = LevelButtons[i];
                t.interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        Fader.FadeTo(levelName);
    }
}

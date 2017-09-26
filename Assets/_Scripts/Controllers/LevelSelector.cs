using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader Fader;

    public void Select(string levelName)
    {
        Fader.FadeTo(levelName);
    }
}

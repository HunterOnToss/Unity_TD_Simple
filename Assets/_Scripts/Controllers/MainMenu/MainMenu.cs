using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad = "Polygon";
    public SceneFader MenuSceneFader;

    public void Play()
    {
        MenuSceneFader.FadeTo(LevelToLoad);
    }

    public void Quit()
    {

        Debug.Log("Exciting ..");
        Application.Quit();
    }

}

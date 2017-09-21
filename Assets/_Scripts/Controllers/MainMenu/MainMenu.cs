using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad = "Polygon";

    public void Play()
    {
        SceneManager.LoadScene(LevelToLoad);
        Debug.Log("Play");
    }

    public void Quit()
    {

        Debug.Log("Exciting ..");
        Application.Quit();
    }

}

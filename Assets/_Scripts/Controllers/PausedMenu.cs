using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    public GameObject Ui;
    public SceneFader GameSceneFader;
    public string MenuSceneName = "MainMenu";

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        Ui.SetActive(!Ui.activeSelf);

        if (Ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        ToggleMenu();
        GameSceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        ToggleMenu();
        GameSceneFader.FadeTo(MenuSceneName);
    }
}

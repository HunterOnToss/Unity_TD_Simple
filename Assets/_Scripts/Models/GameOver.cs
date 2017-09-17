using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text RoundsText;
    
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        //SceneManager.LoadScene(0);
        Debug.Log("Go menu");
    }

    private void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUnit : MonoBehaviour {


	public Unit Value = new Unit ();

	private int key = 0;
	private GameMode gameMode;

	private GameHUD gameHUD;
	private bool move = true;

	private Vector3 screenPosition;
	private Rect backgroundRect, colorRect;

	// Use this for initialization
	void Start () {
//		Value.Health = Value.MaximumHealth;
		gameHUD = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameHUD> ();
		gameMode = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameMode> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (move) {
			if (key <= gameMode.Areas.Count - 1) {
				if (Vector3.Distance (transform.position, gameMode.Areas [key].transform.position) > 0.0f) {
					transform.position = Vector3.MoveTowards (transform.position, gameMode.Areas [key].transform.position, Value.speed * Time.deltaTime);
				} else {
					key++;
				}
			} else {
				move = false;
			}	
		} else {
			gameMode.LosesUnits++; 
			gameMode.GamesUnits.Remove (transform.gameObject);
			Destroy (transform.gameObject);
		}

		if (Value.Health <= 0) {
			gameMode.Diamonds += Value.Diamonds;
			gameMode.GamesUnits.Remove (transform.gameObject);
			Destroy (transform.gameObject);
		}
	}

	void OnGUI () {
		screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		backgroundRect = new Rect (screenPosition.x - 25, Screen.height - (screenPosition.y + 20), 50, 10);
		colorRect = new Rect(screenPosition.x -  25, Screen.height - (screenPosition.y + 20 ), 50 * (Value.Health / Value.MaximumHealth), 10);

		GUI.DrawTexture (backgroundRect, gameHUD.Skin.GetStyle ("HealthBar").normal.background);
		GUI.DrawTexture (colorRect, gameHUD.Skin.GetStyle ("HealthBar").active.background);
		GUI.DrawTexture (backgroundRect, gameHUD.Skin.GetStyle ("HealthBar").hover.background);
	}
}

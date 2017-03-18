using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int gold = 0;
	public int losesUnits = 0;

	public List<GameObject> Zones = new List<GameObject> ();
	public List<GameObject> towersOnTheMap = new List<GameObject> ();
	public float TimeSpawnNextUnit = 2.0f;

	public WaveController waveController;
	public GameHUD gameHUD;

	void Start () {
		waveController = gameObject.GetComponent<WaveController> ();
		waveController.target = Zones [0];

		gameHUD = gameObject.GetComponent<GameHUD> ();
	}

	void LateUpdate () {
		Spawn();
	}

	void Spawn() {

		foreach (GameObject obj in waveController.UnitsOnMaps) {
			UnitController control = obj.GetComponent<UnitController> ();
			control.Zones = Zones;
		}	

	}
		
}

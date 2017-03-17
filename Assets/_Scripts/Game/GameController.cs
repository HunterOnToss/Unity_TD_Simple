using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int gold = 0;
	public int losesUnits = 0;

	public List<GameObject> Zones = new List<GameObject> ();
	public float TimeSpawnNextUnit = 2.0f;
	public WaveController waveController;

	void Start () {
		waveController = (WaveController)gameObject.GetComponent<WaveController> ();
		waveController.target = Zones [0];
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

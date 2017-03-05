using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

//	public Wave Waves;
//	public List<GameObject> Units = new List<GameObject>();
	public List<GameObject> Zones = new List<GameObject> ();

	public WaveController waveController;

	public float TimeSpawnNextUnit = 2.0f;
	private UnitController y;

	void Start () {
		
		waveController = (WaveController)gameObject.GetComponentInParent<WaveController> ();
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

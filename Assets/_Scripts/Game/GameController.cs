using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Wave Waves;
	public List<GameObject> Zones = new List<GameObject> ();
	public List<GameObject> Units = new List<GameObject>();

	public float TimeSpawnNextUnit = 2.0f;

	private WaveController script;
	private UnitController y;

	void Start () {

		script = (WaveController)gameObject.GetComponentInParent<WaveController> ();
		script.target = Zones [0];


	}

	void LateUpdate () {
		
		Spawn();

	}

	void Spawn() {

		foreach (GameObject obj in script.UnitsOnMaps) {
			UnitController control = obj.GetComponent<UnitController> ();
			control.Zones = Zones;
		}	

	}

}

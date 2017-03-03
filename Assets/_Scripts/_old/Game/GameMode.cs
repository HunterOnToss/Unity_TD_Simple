using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

	public int Diamonds = 0;
	public int LosesUnits = 0;

	public int CountWave;
	public int CurrnetWave;

	public List<Wave> Waves = new List<Wave>();
	public List<GameObject> Areas = new List<GameObject> ();
	public List<GameObject> GamesUnits = new List<GameObject> ();

	private float timeWave = 5.0f;
	private float timeUnit = 1.0f;
	private int key;
	private bool created = true;

	void Start() {
		CountWave = Waves.Count;
		CurrnetWave = 0;

	}

	void Update () {

		// === Spawn Logic ===
		if (timeWave <= 0.0f && created) {

			if (CurrnetWave <= CountWave - 1) {
				if (timeUnit <= 0.0f) {
					if (key <= Waves [CurrnetWave].Units.Count - 1) {
						GamesUnits.Add ((GameObject)Instantiate (Waves [CurrnetWave].Units [key], Areas [0].transform.position, Quaternion.identity));
						key++;
						timeUnit = 1.0f;
					} else {
						CurrnetWave++;
						key = 0;
						timeWave = 10.0f;
						timeUnit = 1.0f;
					}
				} else {
					timeUnit -= Time.deltaTime;
				}
			} else {
				Debug.Log ("Level complite!");
				created = false;
			}

		} else {
			timeWave -= Time.deltaTime;
		}
	}
		
}

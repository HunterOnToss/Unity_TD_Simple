using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public Wave NewWave;
	public float NextSpawnTime = 2;
	public int MaxSpawnWave = 2;
	public int CurrentNumberSpawnWave = 0;
	public GameObject target;

	public List<GameObject> UnitsOnMaps = new List<GameObject>();

	void Update() {
		InitWave ();
	}

	void InitWave() {

		if (CurrentNumberSpawnWave <= MaxSpawnWave){
			if (NextSpawnTime <= 0) {

				int y = 0;
				foreach (GameObject obj in NewWave.Units) {
					for (int i = 0; i < NewWave.CountUnitInWave; i++) {
						GameObject temp = Instantiate (obj, new Vector3 (i + y, 0, 0), Quaternion.identity);
						UnitsOnMaps.Add (temp);
						y += 2;
					}

					y = 0;
				}

				CurrentNumberSpawnWave++;
				NextSpawnTime = 5f;
			} else {
				NextSpawnTime -= Time.deltaTime;
			}
		} 


	}
		
 }

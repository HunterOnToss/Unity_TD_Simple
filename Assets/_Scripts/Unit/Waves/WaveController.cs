﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public Wave NewWave;
	public float NextSpawnTime = 2;
	public int MaxSpawnWave = 2;
	public int CurrentNumberSpawnWave = 0;
	public GameObject target;
	public int countDieUnits = 0;

	public List<GameObject> UnitsOnMaps = new List<GameObject>();
	private GameController gameController;

	void Start() {
		gameController = (GameController)gameObject.GetComponent<GameController> ();
	}

	void Update() {
		InitWave ();
	}

	void LateUpdate(){
		CheckFinishMove ();
	}

	void InitWave() {

		if (CurrentNumberSpawnWave <= MaxSpawnWave){
			if (NextSpawnTime <= 0) {

				float y = 0;
				float z = 0;
				foreach (GameObject obj in NewWave.Units) {
					for (int i = 0; i < NewWave.CountUnitInWave; i++) {
						GameObject temp = Instantiate (obj, new Vector3 (i + y, 0, z) + target.transform.position, Quaternion.identity);
						UnitsOnMaps.Add (temp);
						y += 0.5f;
					}
					z += 2.5f;
					y = 0;

				}

				CurrentNumberSpawnWave++;
				NextSpawnTime = 5f;
			} else {
				NextSpawnTime -= Time.deltaTime;
			}
		} 


	}

	void CheckFinishMove() {

		foreach (GameObject obj in UnitsOnMaps.ToArray()) {
			UnitController control = obj.GetComponent<UnitController> ();
			if (control.FinishMove || control.isDie) {
				if (control.isDie) { 
					countDieUnits++;
					gameController.gold += control.unitOnTheMap.gold;
				}

				if (control.FinishMove) {
					gameController.losesUnits++;
				}

				UnitsOnMaps.Remove (obj);
				control.Die ();
			}
		}

	}
		
 }

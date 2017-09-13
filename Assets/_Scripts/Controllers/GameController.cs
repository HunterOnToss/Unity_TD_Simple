using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int gold = 0;
	public int losesUnits = 0;

    public List<GameObject> Zones;
	public List<GameObject> towersOnTheMap = new List<GameObject> ();

	public List<GameObject> towerFrame = new List<GameObject> ();

	public Shop shop;

	public float TimeSpawnNextUnit = 2.0f;

	public WaveController waveController;
	public GameHUD gameHUD;

	void Start ()
	{
	    Zones = Waypoints.Points;

		shop = gameObject.GetComponent<Shop> ();

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

	public void ShowGround(int _id) 
	{
		TowerController tower = shop.shopTowers [_id].GetComponent < TowerController> ();

		if (gold < tower.myTower.cost) {
			Debug.Log ("Not enought minerals");
		} else 
		{

			foreach (GameObject obj in towerFrame) 
			{
				if (obj.GetComponent<TowerFrame>().isBuild)
				{
					obj.SetActive (false);
				} 
				else 
				{
					obj.SetActive (true);
					obj.GetComponent<TowerFrame> ().id = _id;	
				}
			}
		}
	}
		
}

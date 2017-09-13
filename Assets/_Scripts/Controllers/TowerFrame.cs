using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFrame : MonoBehaviour 
{
	public int id;
	public bool isBuild = false;

	private GameController _gameController;
	private Vector3 _towerPoint;

	void Start()
	{
		_gameController = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameController> ();

		_towerPoint = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);

	}

	void OnMouseUp()
	{
		if (!isBuild) 
		{
			
			var tower = Instantiate (_gameController.shop.shopTowers [id], _towerPoint, Quaternion.identity) as GameObject;

			var myTowerClass = tower.GetComponent<TowerController> ().myTower;
			_gameController.gold -= myTowerClass.cost;

			myTowerClass.towerFrame = this;

			_gameController.towersOnTheMap.Add (tower);

			foreach (var obj in _gameController.towerFrame) 
			{
				obj.SetActive (false);
			}
		}

		isBuild = true;
	}
}

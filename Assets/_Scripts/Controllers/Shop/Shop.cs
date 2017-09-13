using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public List<GameObject> buttonTowers = new List<GameObject>();
	public List<GameObject> shopTowers = new List<GameObject>();

	private GameController gameController;


	void Start() 
	{
		gameController = gameObject.GetComponent<GameController> ();
		OnShop ();
	}

	public void OnShop() 
	{

		foreach (var obj in buttonTowers) 
		{
			obj.SetActive (false);
		}

		int i = 0;
		foreach (GameObject obj in shopTowers) 
		{
			if (i < buttonTowers.Count) 
			{
				gameController.gameHUD.textCost [i].text = "" + obj.GetComponent<TowerController> ().myTower.cost;
				buttonTowers [i].SetActive (true);
				i++;
			} 
		}

	}
}

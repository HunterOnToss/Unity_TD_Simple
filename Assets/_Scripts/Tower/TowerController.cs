using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {


	public Tower myTower = new Tower ();
	public GameObject circleSelect;

	private float reload;
	private GameObject bullet;
	private GameController gameController;
	private GameHUD gameHUD;
	private GameObject currentTarger;


	void Start () 
	{
		gameController = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameController>() as GameController; 
		gameHUD = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameHUD>() as GameHUD;
	}

	void Update () {

		if (gameController.waveController.UnitsOnMaps != null) 
		{
			if (reload <= 0.0f) 
			{

				currentTarger = FindTarget ();

				if (currentTarger && Vector3.Distance (transform.position, currentTarger.transform.position) <= myTower.Range) 
				{
					StrikeTarget (currentTarger);
				} 

			}
			else 
			{
				reload -= Time.deltaTime;
			}
		}
	}

	GameObject FindTarget() {

		foreach (GameObject obj in gameController.waveController.UnitsOnMaps) 
		{

			if (Vector3.Distance (transform.position, obj.transform.position) <= myTower.Range) 
			{
				return obj;
			}

		}

		return null;
	}

	void StrikeTarget(GameObject obj) 
	{
		bullet = (GameObject)Instantiate (myTower.bullet, myTower.spawnBullet.transform.position, Quaternion.identity);
		bullet.GetComponent<Bullet> ().Target = obj;
		bullet.GetComponent<Bullet> ().damage = myTower.damage;
		bullet.GetComponent<Bullet> ().speed = myTower.bulletSpeed;

		reload = myTower.attackSpeed;
	}

	void OnMouseUp() 
	{
		if (gameHUD.currentTargetSelected != null) 
		{
			gameHUD.removeSelect ();
		} 

		gameHUD.currentTargetSelected = gameObject;
		circleSelect.SetActive (true);
		gameHUD.descriptionPanel.SetActive (true);
		UpdateInfoAboutTower ();

	}

	public void UpdateInfoAboutTower()
	{
		gameHUD.OnInfo (myTower.name, myTower.level, myTower.damage, 0, 0, 0, true);
	}

	// TODO: make better
	public void Upgrade() 
	{
		if (gameController.gold >= myTower.upgradeCost) 
		{
			gameController.gold -= myTower.upgradeCost;
			myTower.upgradeCost += myTower.upgradeCost / 2;
			myTower.sellCost = myTower.upgradeCost / 3 + 1;
			myTower.level++;
			myTower.damage += myTower.damage / 2;
		}
	}

	public void Sell()
	{
		gameController.gold += myTower.sellCost;
		gameController.towersOnTheMap.Remove (gameObject);
		Destroy (gameObject);
	}

	// ============================================================================

}

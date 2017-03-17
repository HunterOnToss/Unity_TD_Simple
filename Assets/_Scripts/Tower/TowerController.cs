using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {


	public Tower myTower = new Tower ();

	private float reload;
	private int attack;
	private GameObject target;
	private GameObject bullet;
	private GameController gameController;

	private GameObject currentTarger;


	void Start () 
	{
		gameController = (GameController)GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameController>();
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

}

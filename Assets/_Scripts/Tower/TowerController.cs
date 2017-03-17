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

	// Use this for initialization
	void Start () {
		gameController = (GameController)GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (gameController.waveController.UnitsOnMaps != null) {
			
			foreach (var obj in gameController.waveController.UnitsOnMaps) {
						
					if (reload <= 0.0f) { 
						if (Vector3.Distance (transform.position, obj.transform.position) <= myTower.Range) {
							bullet = (GameObject)Instantiate (myTower.bullet, myTower.spawnBullet.transform.position, Quaternion.identity);
							bullet.GetComponent<Bullet> ().Target = obj;
							bullet.GetComponent<Bullet> ().damage = myTower.damage;
							bullet.GetComponent<Bullet> ().speed = myTower.bulletSpeed;

							reload = myTower.attackSpeed;

						}
					} else {
						reload -= Time.deltaTime;
					}
				}
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTower : MonoBehaviour {

	public Tower Value = new Tower ();

	private float reloads;
	private bool attack = false;
	private GameObject target;
	private GameMode gameMode;
	private GameObject bullet;

	// Use this for initialization
	void Start () {
		gameMode = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameMode> ();
		reloads = Value.attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (attack) {

			if (target != null) {
				if (Vector3.Distance (transform.position, target.transform.position) <= Value.Range) {
					if (reloads <= 0.0f) {

						bullet = (GameObject)Instantiate (Value.BulletPref, Value.BulletSpawn.transform.position, Quaternion.identity);
						bullet.GetComponent<Bullet> ().Target = target;
						bullet.GetComponent<Bullet> ().Damage = Value.Damage;
						bullet.GetComponent<Bullet> ().Speed = Value.bulletSpeed;
						Debug.Log (target.name);

						reloads = Value.attackSpeed;

					} else {
						reloads -= Time.deltaTime;
					}
				} else {
					attack = false;
				}
			} else {
				attack = false;
			}

		} else {
			foreach(GameObject obj in gameMode.GamesUnits) {
				if (Vector3.Distance (transform.position, obj.transform.position) <= Value.Range) {
					target = obj;
					attack = true;
				}
			}
		}

	}
}

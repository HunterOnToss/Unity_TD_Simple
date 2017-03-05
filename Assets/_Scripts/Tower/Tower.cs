using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tower {

	public string name = "BaseTurret";
	public int damage = 10;

	public float attackSpeed = 1;
	public float bulletSpeed = 1;
	public float Range = 5;
	public GameObject bullet;
	public GameObject spawnBullet;

}

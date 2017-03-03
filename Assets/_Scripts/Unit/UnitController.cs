using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

	public BaseUnit GameUnit = new SimpleUnit ();
	GameObject test;
	Vector3 point;
	Vector3 distance;

	void Start () {
		Init ();
	}

	void Update () {
		
		point = point + distance;
		test.transform.position = point;
		this.Move (test);
		
	}

	void Init() {
		test = new GameObject ();
		point = new Vector3 (1, 0, 0);
		distance = new Vector3 (1, 0, 0);
	}

	void Move (GameObject _point) {
		transform.position = Vector3.MoveTowards (transform.position, _point.transform.position, this.GameUnit.speed * Time.deltaTime);
	}

	void Die () {
		Debug.Log ("I am die");
		Destroy (transform.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

	public BaseUnit GameUnit = new SimpleUnit ();

	void Start () {
		
	}

	void Update () {
		
	}

	void Move (GameObject _point) {
		transform.position = Vector3.MoveTowards (transform.position, _point.transform.position, this.GameUnit.speed * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

	public BaseUnit GameUnit = new SimpleUnit ();
	public List<GameObject> Zones = new List<GameObject> ();

	public bool FinishMove = false;
	public bool isDie = false;
	private int CurrentZone = 1;

	void Update () {

		if (CurrentZone < Zones.Count) {
			MoveToZone (Zones [CurrentZone]);
		} else {
			FinishMove = true;
		}

		if (GameUnit.health < 0) {
			isDie = true;
		}

	}

	public void Move (GameObject _point) {
		transform.position = Vector3.MoveTowards (transform.position, _point.transform.position, this.GameUnit.speed * Time.deltaTime);
	}

	public void Die () {
		Destroy (transform.gameObject);

	}

	public void MoveToZone( GameObject zone) {

			float res = Vector3.Distance (this.transform.position, zone.transform.position);

			if (res >= 2.0f) {
				Move (zone);

			} else {
				CurrentZone++;
			}

	}

}

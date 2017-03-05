using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage;
	public float speed;
	public GameObject Target;

	void Update() {
		MoveToTarget ();
	}

	void MoveToTarget() {

		if (Target != null) {

			if (Vector3.Distance (transform.position, Target.transform.position) >= 0.8f) {
				transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, speed * Time.deltaTime);
			} else {
				Target.GetComponent<UnitController> ().GameUnit.health -= damage;
				Destroy (transform.gameObject);
			}
			
		} else {
			Destroy (transform.gameObject);
		}

	}

}

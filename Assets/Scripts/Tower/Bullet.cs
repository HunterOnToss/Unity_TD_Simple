using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject Target;
	public int Damage;
	public float Speed;

	void Update () {

		if (Target != null) {
			if (Vector3.Distance (transform.position, Target.transform.position) >= 0.2f) {
				transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, Speed * Time.deltaTime);
			} else {
				Target.GetComponent<InfoUnit> ().Value.Health -= Damage;
				Destroy (transform.gameObject);
			}
		} else {
			Destroy (transform.gameObject);
		}
	}
}

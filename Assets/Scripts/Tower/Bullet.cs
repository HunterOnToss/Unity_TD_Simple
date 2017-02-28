using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject Target;
	public int Damage;
	public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
		if (Vector3.Distance (transform.position, Target.transform.position) >= 0.2f) {
			transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, Speed * Time.deltaTime);
		} else {
			Target.GetComponent<InfoUnit> ().Value.Health -= Damage;
			Destroy (transform.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public List<GameObject> Zones = new List<GameObject> ();


	void Start () {
		foreach (GameObject obj in Zones) {
			print (obj);
		}
	}
	

	void Update () {
		
	}
}

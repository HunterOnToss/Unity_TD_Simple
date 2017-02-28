using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUnit : MonoBehaviour {


	public Unit Value = new Unit ();

	private int key = 0;
	private GameMode gameMode;
	private bool move = true;
	// Use this for initialization
	void Start () {
		gameMode = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameMode> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (move) {
			if (key <= gameMode.Areas.Count - 1) {
				if(Vector3.Distance(transform.position, gameMode.Areas[key].transform.position) > 0.0f) {
					transform.position = Vector3.MoveTowards (transform.position, gameMode.Areas [key].transform.position, Value.speed * Time.deltaTime);
				} else {
					key++;
				}
			} else {
				move = false;
			}	
		}
	}
}

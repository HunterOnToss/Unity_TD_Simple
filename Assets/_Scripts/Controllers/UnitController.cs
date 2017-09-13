﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

	public GameObject circleSelect;
	public BaseUnit unitOnTheMap = new SimpleUnit ();
	public List<GameObject> Zones = new List<GameObject> ();

	public bool FinishMove = false;
	public bool isDie = false;

	private GameHUD gameHUD;
	private int CurrentZone = 1;

	private Vector3 screenPos;
	private Rect backgroundHelthBarRect, colorHelthBarRect;

	void Start() {
		gameHUD = GameObject.FindGameObjectWithTag ("GameMode").GetComponent<GameHUD>();
	}
		
	void Update () {

		if (CurrentZone < Zones.Count) {
			MoveToZone (Zones [CurrentZone]);
		} else {
			FinishMove = true;
		}

		if (unitOnTheMap.health <= 0) {
			isDie = true;
		}

	}

	void OnGUI() {
		string _styleName = "HealthBar";
		float _height = 10;
		float _width = 50;

		screenPos = Camera.main.WorldToScreenPoint (transform.position);
		backgroundHelthBarRect = new Rect (screenPos.x - 25, Screen.height - (screenPos.y + 20), _width, _height);
		colorHelthBarRect = new Rect (screenPos.x - 25, Screen.height - (screenPos.y + 20), _width * (unitOnTheMap.health / unitOnTheMap.maximumHealth), _height);

		GUI.DrawTexture (backgroundHelthBarRect, gameHUD.skin.GetStyle (_styleName).normal.background);
		GUI.DrawTexture (colorHelthBarRect, gameHUD.skin.GetStyle (_styleName).active.background);
		GUI.DrawTexture (backgroundHelthBarRect, gameHUD.skin.GetStyle (_styleName).hover.background);

	}

	void OnMouseUp() 
	{
		if (gameHUD.currentTargetSelected != null) 
		{
			gameHUD.removeSelect ();
		} 

		gameHUD.currentTargetSelected = gameObject;
		circleSelect.SetActive (true);
		UpdateInfoAboutUnit ();
		gameHUD.descriptionPanel.SetActive (true);

	}

	public void UpdateInfoAboutUnit()
	{
		gameHUD.OnInfo (unitOnTheMap.name, unitOnTheMap.level, 0, unitOnTheMap.armor, unitOnTheMap.health, unitOnTheMap.maximumHealth, false);
	}

	public void Move (GameObject _point) {
		transform.position = Vector3.MoveTowards (transform.position, _point.transform.position, this.unitOnTheMap.speed * Time.deltaTime);
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
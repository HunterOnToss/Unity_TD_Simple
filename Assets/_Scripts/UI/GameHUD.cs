using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
 
public class GameHUD : MonoBehaviour {

	public RawImage goldIcon;
	public Text goldText;

	public RawImage losesUnits;
	public Text losesUnitsText;

	private GameController gameController;

	void Start() {
		gameController = transform.GetComponent<GameController> ();
	}

	void LateUpdate() {
		goldText.text = gameController.gold.ToString();
		losesUnitsText.text = gameController.losesUnits.ToString();
	}

}

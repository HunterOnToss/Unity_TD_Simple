using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
 
public class GameHUD : MonoBehaviour {

	public Text goldText;
	public Text losesUnitsText;

	public GUISkin skin;

	// Info Panel
	public GameObject currentTargetSelected;

	public GameObject descriptionPanel;
	public Text textName;
	public Text textLevel;
	public Text textHealth;

	public RawImage imageIcon;
	public GameObject damagePanel;
	public Text textDamage;
	public GameObject armorPanel;
	public Text textArmor;
	private bool isUpdate;

	//controll
	private GameController gameController;
	private TowerController towerController; 
	private UnitController unitController;



	void Start() 
	{
		gameController = transform.GetComponent<GameController> ();
	}

	void LateUpdate() 
	{
		
		goldText.text = gameController.gold.ToString();
		losesUnitsText.text = gameController.losesUnits.ToString();

		if (currentTargetSelected != null) 
		{
			towerController = currentTargetSelected.GetComponent<TowerController> ();
			unitController = currentTargetSelected.GetComponent<UnitController> ();
			isUpdate = true;
			UpdatePanel ();

			if (Input.GetMouseButton (1)) 
			{
				descriptionPanel.SetActive (false);

				switch (currentTargetSelected.tag) 
				{
				case ("Tower"):
					towerController.circleSelect.SetActive (false);
					break;
				case("Unit"):
					unitController.circleSelect.SetActive (false); 
					break;

				}

				currentTargetSelected = null;
			}
		} 
		else if (isUpdate)
		{
			isUpdate = false;
			descriptionPanel.SetActive (false);
		}


	}

	public void OnInfo(string _name, int _level, int _damage, int _armor, float _health,  float _maxHealth, bool _isTower)
	{
		string _lvl = "Level: " + _level;

		if (_isTower) 
		{
			textName.text = _name;
			textLevel.text = _lvl;
			textDamage.text = _damage.ToString();
			textHealth.text = "";
			damagePanel.SetActive (true);
			armorPanel.SetActive (false);
		}
		else 
		{
			textName.text = _name;
			textLevel.text = _lvl;
			textArmor.text = _armor.ToString();
			textHealth.text = _health + " / " + _maxHealth;

			damagePanel.SetActive (false);
			armorPanel.SetActive (true);
		}

	}

	public void removeSelect() 
	{
		switch(currentTargetSelected.tag) 
		{
		case "Tower":
			towerController.circleSelect.SetActive(false);
			break;

		case "Unit":
			unitController.circleSelect.SetActive(false);
			break;

		default:
			Debug.Log ("GameHUD, you are forget TAG: TOWER or UNIT");
			break;
		}
	}

	public void UpdatePanel ()
	{
		switch(currentTargetSelected.tag) 
		{
		case "Tower":
			towerController.UpdateInfoAboutTower();
			break;

		case "Unit":
			unitController.UpdateInfoAboutUnit ();
			break;

		default:
			Debug.Log ("Update doesn't work, you are forget TAG: TOWER or UNIT");
			break;
		}
	}
}

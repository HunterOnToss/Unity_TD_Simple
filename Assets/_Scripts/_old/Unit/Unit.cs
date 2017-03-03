using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit {
	
	public string name;

	public float MaximumHealth;
	public float Health;
	public float Regeneration;
	public float speed = 1f;

	public int armor = 0;
	public int Diamonds = 1;

}

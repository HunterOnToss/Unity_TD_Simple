using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;

	void Update() {

		// ======== move player position ========
		if (Input.mousePosition.x < 2.0f) {
			transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
		}

		if (Input.mousePosition.x > Screen.width - 2.0f) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}

		if (Input.mousePosition.y > Screen.height - 2.0f) {
			transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
		}

		if (Input.mousePosition.y < 2.0f) {
			transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Speed = 10.0f;
    public float LimitPositiveX = 10F;
    public float LimitNegativeX = -24F;
    public float LimitPositiveZ = 8F;
    public float LimitNegativeZ = -25F;

    void Update()
    {
        MovePlayerCamera();
    }

    private void MovePlayerCamera()
    {

        if (transform.position.x > LimitNegativeX)
        {
            if (Input.mousePosition.x < 2.0f)
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            }
        }

        if (transform.position.x < LimitPositiveX)
        {
            if (Input.mousePosition.x > Screen.width - 2.0f)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            }
        }

        if (transform.position.z < LimitPositiveZ)
        {
            if (Input.mousePosition.y > Screen.height - 2.0f)
            {
                transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
            }
        }


        if (transform.position.z > LimitNegativeZ)
        {
            if (Input.mousePosition.y < 2.0f)
            {
                transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
            }
        }
    }
}

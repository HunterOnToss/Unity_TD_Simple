using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Speed = 10.0f;
    public float LimitPositive_X = 10F;
    public float LimitNegative_X = -24F;
    public float LimitPositive_Z = 8F;
    public float LimitNegative_Z = -25F;

    void Update()
    {
        MovePlayerCamera();
    }

    private void MovePlayerCamera()
    {

        if (transform.position.x > LimitNegative_X)
        {
            if (Input.mousePosition.x < 2.0f)
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            }
        }

        if (transform.position.x < LimitPositive_X)
        {
            if (Input.mousePosition.x > Screen.width - 2.0f)
            {
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            }
        }

        if (transform.position.z < LimitPositive_Z)
        {
            if (Input.mousePosition.y > Screen.height - 2.0f)
            {
                transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
            }
        }


        if (transform.position.z > LimitNegative_Z)
        {
            if (Input.mousePosition.y < 2.0f)
            {
                transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
            }
        }
    }
}

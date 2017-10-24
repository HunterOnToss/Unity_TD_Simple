using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float ScrollSpeed = 15f;
    public float Speed = 10.0f;

    public float LimitPositiveX = 10f;
    public float LimitNegativeX = -24f;

    public float LimitPositiveZ = 8f;
    public float LimitNegativeZ = -25f;

    public float LimitPositiveY = 12f;
    public float LimitNegativeY = 4f;

    private enum Coordinate
    {
        X, Y, Z
    }




    void Update()
    {

        if (GameController.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        ZoomPlayerCamera();
        MovePlayerCamera();
        ScrollPlayerCamera();
    }

    private void ScrollPlayerCamera()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        var pos = this.transform.position;
        pos.y -= scroll * 100 * ScrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, LimitNegativeY, LimitPositiveY);

        this.transform.position = pos;
    }

    private void MovePlayerCamera()
    {
        if (Input.mousePosition.x < 2.0f) { MakeLimitCoordinate(Coordinate.X, 1, LimitNegativeX, LimitPositiveX); }
        if (Input.mousePosition.x > Screen.width - 2.0f) { MakeLimitCoordinate(Coordinate.X, -1, LimitNegativeX, LimitPositiveX); }
        if (Input.mousePosition.y > Screen.height - 2.0f) { MakeLimitCoordinate(Coordinate.Z, -1, LimitNegativeZ, LimitPositiveZ); }
        if (Input.mousePosition.y < 2.0f) { MakeLimitCoordinate(Coordinate.Z, 1, LimitNegativeZ, LimitPositiveZ); }
    }

    private void ZoomPlayerCamera()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MakeLimitCoordinate(Coordinate.Y, 1, LimitNegativeY, LimitPositiveY);
        }

        if (Input.GetKey(KeyCode.S)) 
        { 
            MakeLimitCoordinate(Coordinate.Y, -1, LimitNegativeY, LimitPositiveY); 
        }
    }

    private void MakeLimitCoordinate(Coordinate nameCoordinate, int forward, float min, float max)
    {
        var pos = this.transform.position;

        switch (nameCoordinate)
        {
            case Coordinate.X:
                pos.x -= forward * Speed * Time.deltaTime;
                pos.x = Mathf.Clamp(pos.x, min, max);
                break;
            case Coordinate.Y:
                pos.y -= forward * Speed * Time.deltaTime;
                pos.y = Mathf.Clamp(pos.y, min, max);
                break;
            case Coordinate.Z:
                pos.z -= forward * Speed * Time.deltaTime;
                pos.z = Mathf.Clamp(pos.z, min, max);
                break;
        }

        this.transform.position = pos;
    }
}

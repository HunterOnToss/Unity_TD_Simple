import UnityEngine


class MyCameraController(MonoBehaviour):
	
    public ScrollSpeed = 15.0
    public Speed = 10.0

    public LimitPositiveX = 10.0
    public LimitNegativeX = -24.0

    public LimitPositiveZ = 8.0
    public LimitNegativeZ = -25.0

    public LimitPositiveY = 12.0
    public LimitNegativeY = 4.0

    enum Coordinate:
        X
        Y
        Z



    def Update():
    	#if (GameController.GameIsOver):        
        #   self.enabled = false
        #    return
        
        ZoomPlayerCamera()
        MovePlayerCamera()
        ScrollPlayerCamera()

    def ScrollPlayerCamera():
        scroll = Input.GetAxis('Mouse ScrollWheel')
        pos = transform.position
        pos.y -= scroll * 100 * ScrollSpeed * Time.deltaTime
        pos.y = Mathf.Clamp(pos.y, LimitNegativeY, LimitPositiveY)
        self.transform.position = pos

    def MovePlayerCamera():
        if (Input.mousePosition.x < 2.0f): MakeLimitCoordinate(Coordinate.X, 1, LimitNegativeX, LimitPositiveX)
        if (Input.mousePosition.x > Screen.width - 2.0f): MakeLimitCoordinate(Coordinate.X, -1, LimitNegativeX, LimitPositiveX)
        if (Input.mousePosition.y > Screen.height - 2.0f): MakeLimitCoordinate(Coordinate.Z, -1, LimitNegativeZ, LimitPositiveZ)
        if (Input.mousePosition.y < 2.0f): MakeLimitCoordinate(Coordinate.Z, 1, LimitNegativeZ, LimitPositiveZ)

    def ZoomPlayerCamera():
        if (Input.GetKey(KeyCode.W)):
        	MakeLimitCoordinate(Coordinate.Y, 1, LimitNegativeY, LimitPositiveY)

        if (Input.GetKey(KeyCode.S)):
        	MakeLimitCoordinate(Coordinate.Y, -1, LimitNegativeY, LimitPositiveY)

    def MakeLimitCoordinate(nameCoordinate as Coordinate, forward as int, min as single, max as single):
        pos = self.transform.position

        if nameCoordinate == Coordinate.X:
            pos.x -= forward * Speed * Time.deltaTime
            pos.x = Mathf.Clamp(pos.x, min, max)
        elif nameCoordinate == Coordinate.Y:
            pos.y -= forward * Speed * Time.deltaTime
            pos.y = Mathf.Clamp(pos.y, min, max)
        elif Coordinate.Z:
            pos.z -= forward * Speed * Time.deltaTime
            pos.z = Mathf.Clamp(pos.z, min, max)

        self.transform.position = pos
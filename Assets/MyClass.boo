import UnityEngine

class MyClass (MonoBehaviour): 
	
	public speed = 15f
	public super_speed = 100
	health = 10

	def Start ():
		s = "hello"
		Debug.Log(s)
	
	def Update ():
		
		
		if (Input.GetKey(KeyCode.W)):
			transform.position += Vector3.forward

		r = MakeSimple(super_speed)
		Debug.Log(r)

		for i in range(1, 100):
			print i

	def MakeSimple(n as int) as int:
		if n == 1:
			n += 100
		else:
			n += 200

		n += 100
		k = 100
		n = n * k
		return n
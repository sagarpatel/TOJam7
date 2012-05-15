using UnityEngine;
using System.Collections;

public class PlayerFTL : MonoBehaviour 
{

	public bool isFTL = true;
	public float currentTime;
	public float ftlTime;
	public float ftlSpeed = 2;

	public float currentVel;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		
		currentTime += Time.time;
		if(isFTL)
		{
			if(currentTime > ftlTime)
			{
				CharacterController controller = GetComponent<CharacterController>();

				Vector3 tempVector = controller.velocity;
				currentVel = tempVector.y;
				tempVector.y += tempVector.y * ftlSpeed;
				
				controller.Move(tempVector);
			}

		}

	
	}
}

using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

public float fallOffWorldHeight = -20;
public float respawnHeight = 20;

	// Use this for initialization
	void Start () 
	{
	//	collider.isTrigger = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(transform.position.y < fallOffWorldHeight)
		{
			Vector3 tempPosition = transform.position;
			tempPosition.y = respawnHeight;
			transform.position = tempPosition;
		}
	
	}

	/*

	void OnControllerColliderHit(ControllerColliderHit hit) 
	{


		if( hit.gameObject.ToString() == "Checkpoint")
		{

			Debug.Log("Touching checkpoint");

			hit.gameObject.GetComponent<CheckpointScript>().deathHeight = fallOffWorldHeight;
			hit.gameObject.GetComponent<CheckpointScript>().spawnHeight = respawnHeight;

		}


	}

	*/

	
}

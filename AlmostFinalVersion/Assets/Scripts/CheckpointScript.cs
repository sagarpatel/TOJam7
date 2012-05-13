using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour 
{

	public float spawnHeight;
	public float deathHeight;

	public int progressionIndexToSet;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void OnTriggerEnter() 
	{

		 Debug.Log("Hello");

		PlayerScript player = (PlayerScript) GameObject.Find("Player").GetComponent("PlayerScript");
		player.fallOffWorldHeight = deathHeight;
		player.respawnHeight = spawnHeight;
		
		AudioDirectorScript audioDirector = (AudioDirectorScript) GameObject.Find("AudioDirector").GetComponent("AudioDirectorScript");
		audioDirector.layerProgressIndex = progressionIndexToSet;


		for(int i = 0; i<= progressionIndexToSet ; i++)
		{
			audioDirector.audioSourceArray[i].volume = 1;
		}


	}


}

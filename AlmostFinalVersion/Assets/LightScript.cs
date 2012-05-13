using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

	public float lightIntensityValue;
	public float lightIntensityScale = 1.0f;

	public AudioDirectorScript audioDirector;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		lightIntensityValue = audioDirector.rgbAverage * lightIntensityScale;


		light.intensity = lightIntensityValue;
	
	}
}

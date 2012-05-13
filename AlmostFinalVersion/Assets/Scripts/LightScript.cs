using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

	public float lightIntensityValue;
	public float lightIntensityScale = 1.0f;

	public AudioDirectorScript audioDirector;

	public bool isColor = false;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		lightIntensityValue = audioDirector.rgbAverage * lightIntensityScale;
		light.intensity = lightIntensityValue;

		if(isColor)
		{
			Color tempColor = new Color(audioDirector.colorArray[0], audioDirector.colorArray[1], audioDirector.colorArray[2], audioDirector.colorArray[3]);
			light.color = tempColor;
		}
		else
		{
			light.color = new Color(1,1,1,1);
		}
	


	}
}

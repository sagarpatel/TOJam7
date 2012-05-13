using UnityEngine;
using System.Collections;

using System.Collections.Generic;



public class AudioDirectorScript : MonoBehaviour 
{


	public float[] sampleArrayFreq = new float[1024];
	public float[] sampleArrayTime = new float[1024];
	public float[] colorArray =  new float[4];
	public float rgbAverage;

	public float rScale = 20.0f;
	public float gScale = 20.0f;
	public float bScale = 20.0f;
	public float aScale = 20.0f;
	
	const int maxLayerCount = 10;
	public AudioSource[] audioSourceArray = new AudioSource[maxLayerCount];

	public int layerProgressIndex = -1;


	public float mouseWheelScroll = 0;
	public float mouseWheelScale = 0.5f;

	// Use this for initialization
	void Start () 
	{

		





	}
	
	// Update is called once per frame
	void Update () 
	{

		Controls();
		
		AudioListener.GetOutputData(sampleArrayTime, 0);
		AudioListener.GetSpectrumData(sampleArrayFreq, 0, FFTWindow.Rectangular);

		float sum = 0;
		for(int c = 0; c<4; c++)
		{
			for(int i= c * 16; i < c*16 + 16; i++)
			{
				sum += sampleArrayFreq[i];
			}
			colorArray[c] = sum/16 ;

			sum = 0;
		}

		colorArray[0] *= rScale;
		colorArray[1] *= gScale;
		colorArray[2] *= bScale;
		colorArray[3] *= aScale;

		rgbAverage = (colorArray[0] + colorArray[1] + colorArray[2])/3.0f;

	
	}






	void Controls()
	{


		mouseWheelScroll = Input.GetAxis("Mouse ScrollWheel");
		// apply vollume control to all tracks unlocked so far
		
		for(int i = 0; i<= layerProgressIndex ; i++)
		{
			float tempVol =  audioSourceArray[i].volume;
			tempVol += mouseWheelScroll * mouseWheelScale;
			audioSourceArray[i].volume = tempVol;
			
		}



		/* if ( Input.GetMouseButton( 1 ) )
		 {
		 	audioSource1.pitch = 1;
		 }

		 */


	}






}

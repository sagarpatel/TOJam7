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
	
	const int maxLayerCount = 5;
	public AudioSource[] audioSourceArray = new AudioSource[maxLayerCount];

	public int layerCount;

	public int layerProgressIndex = -1;


	public float mouseWheelScroll = 0;
	public float mouseWheelScale = 0.5f;

	// Use this for initialization
	void Start () 
	{

		for(int i = 0; i < layerCount ; i++)
		{
			audioSourceArray[i].Play();
			audioSourceArray[i].volume = 0;

		}





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

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{

			layerProgressIndex = 0;
			for(int i = 0; i<= layerProgressIndex ; i++)
			{
				audioSourceArray[i].volume = 1;
			}
			
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			layerProgressIndex = 1;
			for(int i = 0; i<= layerProgressIndex ; i++)
			{
				audioSourceArray[i].volume = 1;
			}

		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			layerProgressIndex = 2;
			for(int i = 0; i<= layerProgressIndex ; i++)
			{
				audioSourceArray[i].volume = 1;
			}


		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			layerProgressIndex = 3;
			for(int i = 0; i<= layerProgressIndex ; i++)
			{
				audioSourceArray[i].volume = 1;
			}


		}

		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			layerProgressIndex = 4;
			for(int i = 0; i<= layerProgressIndex ; i++)
			{
				audioSourceArray[i].volume = 1;
			}


		}


		for(int i = layerProgressIndex +1; i< layerCount ; i++)
		{
			audioSourceArray[i].volume = 0;
		}


		

		/* if ( Input.GetMouseButton( 1 ) )
		 {
		 	audioSource1.pitch = 1;
		 }

		 */


	}






}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlatformGeneratorScript : MonoBehaviour 
{

	public AudioDirectorScript audioDirectorScript;

	public GameObject platformType;
	public List<GameObject> platformList;
	public int platformCount = 64;


	public float platformDepthOffset = 1;
	public float distanceBetweenPlatforms = 0.1f;

	public float heightScale = 100.0f;
	public float targetHeight = 10;
	public float extraGravityImpulseScale =1;
	public float negativeImpulseScale = 1;

	public float floorHeight = 0;

	public bool isFrequency = true;

	public float platformDrag = 1;

	public bool isCircular = false;

	public float platformScaleX = 1;
	public float platformScaleY = 1;
	public float platformScaleZ = 1;

	// Use this for initialization
	void Start () 
	{
		platformList =  new List<GameObject>();
		for(int i = 0; i < platformCount; i++)
		{
			platformList.Add((GameObject)Instantiate(platformType, transform.localPosition, transform.localRotation));

			// set as child of generator
			platformList[i].transform.parent = transform;
			platformList[i].rigidbody.drag = platformDrag;

			Vector3 pScale = new Vector3(platformScaleX, platformScaleY, platformScaleZ);
			platformList[i].transform.localScale = pScale;

			if(isCircular)
			{

			}
			//normal straigh platform
			else
			{
				float tempDepth = platformList[i].transform.localScale.z;
				Vector3 tempPosition = platformList[i].transform.localPosition;
				float newDepth = platformDepthOffset + i * tempDepth;
				newDepth += i*distanceBetweenPlatforms;
				tempPosition.z = newDepth;
				platformList[i].transform.localPosition = tempPosition;
			}

		}

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Color tempColor = new Color(audioDirectorScript.colorArray[0], audioDirectorScript.colorArray[1], audioDirectorScript.colorArray[2], audioDirectorScript.colorArray[3]);

		for(int i =0; i< platformCount; i++)
		{

			float audioDataToUse = 0;

			if(isFrequency)
			{
				audioDataToUse = audioDirectorScript.sampleArrayFreq[64-i];
			}
			else
			{
				audioDataToUse = audioDirectorScript.sampleArrayTime[64-i];
			}


			//move and color
			float impulseValue = audioDataToUse * heightScale;
			float currentHeight = platformList[i].transform.localPosition.y;

			if(currentHeight > targetHeight)
			{
				impulseValue = impulseValue - (currentHeight - targetHeight) * negativeImpulseScale;
			}
			else
			{
				impulseValue = impulseValue - currentHeight * extraGravityImpulseScale;
			}


			platformList[i].rigidbody.AddRelativeForce( Vector3.up * impulseValue, ForceMode.Impulse);
			platformList[i].renderer.material.color = tempColor;


			// check floor
			if(platformList[i].transform.localPosition.y < floorHeight)
			{
				Vector3 tempPosition = platformList[i].transform.localPosition;
				tempPosition.y = floorHeight;
				platformList[i].transform.localPosition = tempPosition;
			}

		}


		
	}





}

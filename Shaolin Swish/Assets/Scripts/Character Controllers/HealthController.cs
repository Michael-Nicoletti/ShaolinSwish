using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	public SpriteRenderer heartOne;
	public SpriteRenderer heartTwo;
	public SpriteRenderer heartThree;

	private int timesActivated = 0;

	public void HealthRemoved()
	{
		timesActivated++;

		if (timesActivated == 1) 
		{
			heartThree.enabled = false;
		} else if (timesActivated == 2) 
		{
			heartTwo.enabled = false;
		} else if (timesActivated == 3) 
		{
			heartOne.enabled = false;
		}
	}


}

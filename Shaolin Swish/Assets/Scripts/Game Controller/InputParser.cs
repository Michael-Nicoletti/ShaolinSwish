﻿using UnityEngine;
using System.Collections;

public static class InputParser {

	public static bool pause = false;


	//Had to change this because I dont know a better solution. At the present moment we
	//return things like this for these attack buttons:
	// -1		WE ARE PAUSED
	// 0		WE DIDNT HIT A BUTTON
	// 1		FIRST PLAYER HIT THE BUTTON
	// 2		SECOND PLAYER HIT THE BUTTON
	public static int GetWaterButton()
	{
		if (pause)
		{
			return -1;
		}

		if (Input.GetKeyDown (KeyCode.Q))
		{
			return 1;
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			return 2;
		}

		return 0;
	}


	public static int GetFireButton()
	{
		if (pause)
		{
			return -1;
		}

		if (Input.GetKeyDown (KeyCode.W))
		{
			return 1;
		}

		if(Input.GetKeyDown(KeyCode.O))
		{
			return 2;
		}

		return 0;
		
	}

	public static int GetEarthButton()
	{
		if (pause)
		{
			return -1;
		}

		if (Input.GetKeyDown (KeyCode.E))
		{
			return 1;
		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			return 2;
		}

		return 0;
	}

}

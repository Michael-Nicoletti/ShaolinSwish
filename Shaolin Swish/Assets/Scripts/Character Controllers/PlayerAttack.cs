using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private GameManager gM;

	// Use this for initialization
	void Start () {
	
		gM = FindObjectOfType<GameManager> ();

	}
	
	// Currently checks player input for types of attacks
	void Update () {

		CheckWaterButton ();

		CheckEarthButton ();	

		CheckFireButton ();
	}


	// ----- BUTTON CHECKS ----- //
	void CheckWaterButton()
	{
		switch (InputParser.GetWaterButton ()) 
		{
		case -1:
			Debug.Log ("WE ARE PAUSED");
			break;

		case 0:
			//Debug.Log ("WE DIDNT RETURN ANYTHING");
			break;
		case 1:
			Debug.Log ("Player One Water");
			if (GameManager.playerTurn == 1)
			{
				GameManager.getPlayerTwo ().GetComponent<RoundController> ().setTypeOfAttack (0);
			}
			break;
		case 2:
			Debug.Log ("Player Two Water");
			if (GameManager.playerTurn == 2)
			{
				GameManager.getPlayerOne ().GetComponent<RoundController> ().setTypeOfAttack (0);
			}
			break;
		}
	}
		
	void CheckEarthButton()
	{
		switch (InputParser.GetEarthButton ()) 
		{
		case -1:
			Debug.Log ("WE ARE PAUSED");
			break;

		case 0:
			//Debug.Log ("WE DIDNT RETURN ANYTHING");
			break;
		case 1:
			Debug.Log ("Player One Earth");
			if (GameManager.playerTurn == 1)
			{
				GameManager.getPlayerTwo ().GetComponent<RoundController> ().setTypeOfAttack (1);
			}
			break;
		case 2:
			Debug.Log ("Player Two Earth");
			if (GameManager.playerTurn == 2)
			{
				GameManager.getPlayerOne ().GetComponent<RoundController> ().setTypeOfAttack (1);
			}
			break;
		}
	}


	void CheckFireButton()
	{
		switch (InputParser.GetFireButton ()) 
		{
		case -1:
			Debug.Log ("WE ARE PAUSED");
			break;

		case 0:
			//Debug.Log ("WE DIDNT RETURN ANYTHING");
			break;
		case 1:
			Debug.Log ("Player One Fire");
			if (GameManager.playerTurn == 1)
			{
				GameManager.getPlayerTwo ().GetComponent<RoundController> ().setTypeOfAttack (2);
			}
			break;
		case 2:
			Debug.Log ("Player Two Fire");
			if (GameManager.playerTurn == 2)
			{
				GameManager.getPlayerOne ().GetComponent<RoundController> ().setTypeOfAttack (2);
			}
			break;
		}
	}

	// ----- BUTTON CHECKS ----- //



}

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

		//CheckWaterButton ();

		//CheckEarthButton ();	

		//CheckFireButton ();
	}


	// ----- BUTTON CHECKS ----- //
	public bool CheckWaterButton()
	{
		switch (InputParser.GetWaterButton ()) 
		{
		case -1:
			Debug.Log ("WE ARE PAUSED");
			return false;
			break;

		case 0:
			//Debug.Log ("WE DIDNT RETURN ANYTHING");
			return false;
			break;
		case 1:
			if (gM.playerTurn == 1)
			{
				Debug.Log ("Player One Water");
				//gM.getPlayerTwo ().GetComponent<RoundController> ().setTypeOfAttackIncoming (0);
				return true;
			}
			break;
		case 2:
			if (gM.playerTurn == 2)
			{
				Debug.Log ("Player Two Water");
				//gM.getPlayerOne ().GetComponent<RoundController> ().setTypeOfAttackIncoming (0);
				return true;
			}
			break;

		default:
			return false;
		}
		return false;
	}
		
	public bool CheckEarthButton()
	{
		switch (InputParser.GetEarthButton ()) 
		{
		case -1:
			Debug.Log ("WE ARE PAUSED");
			return false;
			break;

		case 0:
			//Debug.Log ("WE DIDNT RETURN ANYTHING");
			return false;
			break;
		case 1:
			Debug.Log ("Player One Earth");
			if (gM.playerTurn == 1)
			{
				//gM.getPlayerTwo ().GetComponent<RoundController> ().setTypeOfAttackIncoming (1);
				return true;
			}
			break;
		case 2:
			Debug.Log ("Player Two Earth");
			if (gM.playerTurn == 2)
			{
				//gM.getPlayerOne ().GetComponent<RoundController> ().setTypeOfAttackIncoming (1);
				return true;
			}
			break;

		default:
			return false;
		}
		return false;
	}


	public bool CheckFireButton()
	{
		switch (InputParser.GetFireButton ()) 
		{
		case -1:
			Debug.Log ("WE ARE PAUSED");
			return false;
			break;

		case 0:
			//Debug.Log ("WE DIDNT RETURN ANYTHING");
			return false;
			break;
		case 1:
			Debug.Log ("Player One Fire");
			if (gM.playerTurn == 1)
			{
				//gM.getPlayerTwo ().GetComponent<RoundController> ().setTypeOfAttackIncoming (2);
				return true;
			}
			break;
		case 2:
			Debug.Log ("Player Two Fire");
			if (gM.playerTurn == 2)
			{
				//gM.getPlayerOne ().GetComponent<RoundController> ().setTypeOfAttackIncoming (2);
				return true;
			}
			break;

		default:
			return false;
		}
		return false;
	}

	// ----- BUTTON CHECKS ----- //



}

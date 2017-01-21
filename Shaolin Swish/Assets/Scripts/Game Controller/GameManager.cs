using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Public bools
	private bool inMenu = false;

	//Private ints
	public int playerTurn = 1;
	private int turnNumber = 0;

	public static GameManager instance;


	private GameObject playerOne;
	private GameObject playerTwo;


	// Use this for initialization
	void Start () {

		instance = this;

		DontDestroyOnLoad (this);

		playerOne = GameObject.Find ("playerOne");
		playerTwo = GameObject.Find ("playerTwo");
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerTurn);
	}

	public void changeTurn()
	{
		if (playerTurn == 1)
		{
			CameraController.instance.swapCameraPos (2);
			playerTurn = 2;
		}
		else if (playerTurn == 2)
		{
			CameraController.instance.swapCameraPos (1);
			playerTurn = 1;
		}

		turnNumber++;
	}


	public GameObject getPlayerOne()
	{
		return playerOne;
	}

	public GameObject getPlayerTwo()
	{
		return playerTwo;
	}

	public int getTurnNumber()
	{
		return turnNumber;
	}

	public void ResetTurnNumber()
	{
		turnNumber = 0;
	}
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Public bools
	private bool inMenu = false;

	//Private ints
	public int playerTurn = -1;
	private int turnNumber = 0;


	private GameObject playerOne;
	private GameObject playerTwo;


	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (this);

		playerOne = GameObject.Find ("playerOne");
		playerTwo = GameObject.Find ("playerTwo");
	
	}
	
	// Update is called once per frame
	void Update () {


		//This will control whose turn it is to input actions. This will then impact
		//the PlayerAttack script
		if (playerTurn == 0) {


		}
	
	}


	public GameObject getPlayerOne()
	{
		return playerOne;
	}

	public GameObject getPlayerTwo()
	{
		return playerTwo;
	}
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	//Private ints
	public int playerTurn = 1;
	private int turnNumber = 0;

	public static GameManager instance;


	private GameObject playerOne;
	private GameObject playerTwo;


	private PlayerStats[] playerStats;

	// Use this for initialization
	void Start () {

		playerStats = new PlayerStats[2];

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

	public void syncPlayerStats()
	{
		playerStats [0] = playerOne.GetComponent<PlayerStats> ();
		playerStats [1] = playerTwo.GetComponent<PlayerStats> ();
	}

	/// <summary>
	/// Anything that isnt 0 or 1 is null and will break the hell out of the game/// </summary>
	/// <returns>The player stats.</returns>
	/// <param name="playerNum">Player number.</param>
	public PlayerStats getPlayerStats(int playerNum)
	{
		return playerStats [playerNum];
	}

	public void resetGame()
	{
		playerTurn = 1;
		turnNumber = 0;
	}
}

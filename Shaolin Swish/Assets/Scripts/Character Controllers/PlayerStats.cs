using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

	public static int MAX_HEALTH = 30;

	private int roundsWon;

	private int timesUsedWater;
	private int timesUsedEarth;
	private int timesUsedFire;

	public bool wonGame = false;


	public int health;

	// Use this for initialization
	void Start () {
		health = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			SceneManager.LoadScene ("MenuRoundCompleted");
			//@note: Add the death animation and a coroutine to wait for it to end.
		}
	
	}


	/// <summary>
	///0 = add to water
	///1 = add to earth
	///2 = add to fire
	/// 
	/// Round winner only adds one if the player wins the round
	/// </summary>
	public void updateStats(bool roundWinner, int attackType = -1)
	{
		if (attackType != -1)
		{
			switch(attackType)
			{
			case 0:
				timesUsedWater++;
				break;
			case 1:
				timesUsedEarth++;
				break;
			case 2: 
				timesUsedFire++;
				break;
			default:
				break;
			}
		}

		if (roundWinner) 
		{
			roundsWon++;
		}

		GameManager.instance.syncPlayerStats ();
	}

	public int getRoundsWon()
	{
		
		return roundsWon;
	}

	/// <summary>
	/// Gets the most used element. Returns the String of which was most used.
	/// </summary>
	/// <returns>The most used element.</returns>
	public string getMostUsedElement()
	{
		int i = 0;
		string returnElement;

		i = timesUsedWater;
		returnElement = "Water";

		if (i < timesUsedFire)
		{
			i = timesUsedFire;
			returnElement = "Fire";
		}

		if (i < timesUsedEarth) 
		{
			i = timesUsedEarth;
			returnElement = "Earth";
		}

		return returnElement;
	}

	public string getWonGame()
	{
		if (wonGame)
			return "Winner!";
		else
			return
				"Loser!";
	}
}

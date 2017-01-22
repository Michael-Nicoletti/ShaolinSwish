using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	public TextMesh[] playerOneText;
	public TextMesh[] playerTwoText;

	// Use this for initialization
	void Start () {

		playerTwoText [0].text = GameManager.instance.getPlayerStats (0).getWonGame ();
		playerTwoText [1].text = GameManager.instance.getPlayerStats (0).getRoundsWon ().ToString();
		playerTwoText [2].text = GameManager.instance.getPlayerStats (0).getMostUsedElement();

		playerOneText [0].text = GameManager.instance.getPlayerStats (1).getWonGame ();
		playerOneText [1].text = GameManager.instance.getPlayerStats (1).getRoundsWon ().ToString();
		playerOneText [2].text = GameManager.instance.getPlayerStats (1).getMostUsedElement();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

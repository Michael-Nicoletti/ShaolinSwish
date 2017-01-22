using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {


	public SpriteRenderer sR;

	public Sprite Attack;
	public Sprite Defend;

	void Update () {
		if (FindObjectOfType<GameManager> ().playerTurn != GetComponent<RoundController> ().characterNumber) 
		{
			sR.enabled = false;
		}
	}

	public void ShowAttack()
	{
		if(!sR.enabled)
			sR.enabled = true;

		sR.sprite = Attack;
	}

	public void ShowDefend()
	{
		if(!sR.enabled)
			sR.enabled = true;
		
		sR.sprite = Defend;
	}

	public void HideRenderer()
	{
		sR.enabled = false;
	}

}

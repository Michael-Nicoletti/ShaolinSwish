using UnityEngine;
using System.Collections;

public class RoundController : MonoBehaviour {

	private GameManager gM;
	private bool incomingAttack = false;
	private int typeOfAttackIncoming = -1;

	private bool failedDefend = false;

	private float phaseOneTimer = Mathf.Infinity;
	private float phaseTwoTimer = Mathf.Infinity;
	private float phaseThreeTimer = Mathf.Infinity;


	public GameObject enemy;
	public int characterNumber;

	// Use this for initialization
	void Start () {

		gM = FindObjectOfType<GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (failedDefend)
		{
			PhaseThree ();
			return;
		}

		if (phaseOneTimer > 0 && incomingAttack) {
			PhaseOne ();
		} else {
			PhaseTwo ();
		}


	
	}

	//Round Logic.
	//Rounds are basically broken into two phases in most cases else its three
	//Phase 1 is the blocking phase. IF we have an incoming attack then we attempt to block it
	//Phase 2 is the attack phase. If we blocked the attack then send out a new attack
	//Phase 3 (Sometimes occurs) is if we take damage from the attack. We do our calculations and reset the time on rounds
	void PhaseOne()
	{
		if (phaseOneTimer == Mathf.Infinity)
		{
			if (gM.getTurnNumber () < 7)
				phaseOneTimer = 5 - (gM.getTurnNumber () * 0.5f);
			else
				phaseOneTimer = 0.5f;
		}

		if (incomingAttack)
		{
			switch (typeOfAttackIncoming)
			{
			case 1:
				if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) {
					Debug.Log ("Defended");
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					//Success on defend
				} else if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) {
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				} else if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) {
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				}
				break;
			case 2:
				if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) {
					Debug.Log ("Defended");
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					//Success on defend
				} else if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) {
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				} else if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) {
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				}
				break;
			case 3:
				if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) {
					Debug.Log ("Defended");
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					//Success on defend
				} else if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) {
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				} else if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) {
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				}
				break;	
			}
		}

		if (phaseOneTimer <= 0) 
		{
			phaseOneTimer = Mathf.Infinity;
			incomingAttack = false;
			failedDefend = true;
		}


		phaseOneTimer -= Time.deltaTime;

		PrintText.instance.UpdateText("Phase One for: "+this.gameObject.name+ " time left: "+phaseOneTimer);
	}

	void PhaseTwo()
	{
		if (gM.playerTurn != characterNumber)
		{
			return;
		}

		if (phaseTwoTimer == Mathf.Infinity)
		{
			if(gM.getTurnNumber() < 7)
				phaseTwoTimer = 5 - (gM.getTurnNumber() * 0.5f);
			else
				phaseTwoTimer = 0.5f;
		}

		if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) 
		{
			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming(1);
			GetComponent<PlayerStats> ().updateStats (false, 0);
			phaseTwoTimer = Mathf.Infinity;
			gM.changeTurn ();
		}
		else if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) 
		{
			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming (2);
			GetComponent<PlayerStats> ().updateStats (false, 1);
			phaseTwoTimer = Mathf.Infinity;
			gM.changeTurn ();
		}
		else if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) 
		{
			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming (3);
			GetComponent<PlayerStats> ().updateStats (false, 2);
			phaseTwoTimer 	= Mathf.Infinity;
			gM.changeTurn ();
		}

		if (phaseTwoTimer <= 0) 
		{
			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming (-1);
			phaseTwoTimer = Mathf.Infinity;
			gM.changeTurn ();
		}

		phaseTwoTimer -= Time.deltaTime;

		PrintText.instance.UpdateText ("Phase Two for: "+this.gameObject.name+ " time left: "+phaseTwoTimer);
		
	}

	void PhaseThree()
	{
		if (phaseThreeTimer == Mathf.Infinity)
		{
			phaseThreeTimer = 10;
		}

		calculateDamage ();
		gM.ResetTurnNumber ();

		phaseThreeTimer -= Time.deltaTime;

		PrintText.instance.UpdateText("Phase Three for: "+this.gameObject.name+ " time left: "+phaseThreeTimer);
		failedDefend = false;
	}

	//Simple getters and setters for the attacks so we can defend
	private int getTypeOfAttack()
	{
		return typeOfAttackIncoming;
	}


	/// <summary>
	/// -1 = player didnt input anything! Go directly to phase two!
	/// 0 = Water
	/// 1 = Earth
	/// 2 = Fire
	/// </summary>
	/// <param name="attack">Attack.</param>
	public void setTypeOfAttackIncoming(int attack)
	{
		if (attack == -1) 
		{
			gM.ResetTurnNumber ();
			return;
		}

		Debug.Log ("Attack");
		typeOfAttackIncoming = attack;
		incomingAttack = true;
	}

	void calculateDamage()
	{
		enemy.GetComponent<PlayerStats> ().health -= 10;

		if (enemy.GetComponent<PlayerStats> ().health <= 0) {
			GetComponent<PlayerStats> ().wonGame = true;
		}

		GetComponent<PlayerStats> ().updateStats (true);
	}
}

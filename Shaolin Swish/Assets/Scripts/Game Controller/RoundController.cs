using UnityEngine;
using System.Collections;

public class RoundController : MonoBehaviour {

	private GameManager gM;
	private bool incomingAttack = false;
	private int typeOfAttack = -1;

	private bool tookDamage = false;

	private float phaseOneTimer = Mathf.Infinity;
	private float phaseTwoTimer = Mathf.Infinity;
	private float phaseThreeTimer = Mathf.Infinity;

	// Use this for initialization
	void Start () {

		gM = FindObjectOfType<GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (phaseOneTimer > 0) {
			PhaseOne ();
		} else if (phaseTwoTimer > 0) {
			PhaseTwo ();
		} else if (phaseThreeTimer > 0 && tookDamage) {
			PhaseThree ();
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
			phaseOneTimer = 10;
		}

		if (incomingAttack)
		{
			switch (typeOfAttack)
			{

			}
		}


		phaseOneTimer -= Time.deltaTime;

		Debug.Log ("Phase One");
	}

	void PhaseTwo()
	{
		if (phaseTwoTimer == Mathf.Infinity)
		{
			phaseTwoTimer = 10;
		}


		phaseTwoTimer -= Time.deltaTime;

		Debug.Log ("Phase Two");
		
	}

	void PhaseThree()
	{
		if (phaseThreeTimer == Mathf.Infinity)
		{
			phaseThreeTimer = 10;
		}


		phaseThreeTimer -= Time.deltaTime;

		Debug.Log ("Phase Three");
	}



	void CheckPhases()
	{
		//WE HAD AN INCOMING ATTACK! BLOCK IT!
		if (incomingAttack)
		{
			
		}
	}


	//Simple getters and setters for the attacks so we can defend
	private int getTypeOfAttack()
	{
		return typeOfAttack;
	}


	/// <summary>
	/// 0 = Water
	/// 1 = Earth
	/// 2 = Fire
	/// </summary>
	/// <param name="attack">Attack.</param>
	public void setTypeOfAttack(int attack)
	{
		typeOfAttack = attack;
		incomingAttack = true;
	}
}

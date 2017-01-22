using UnityEngine;
//using UnityEditor;
using System.Collections;

public class RoundController : MonoBehaviour {

	private GameManager gM;
	private bool incomingAttack = false;
	private int typeOfAttackIncoming = -1;

	private bool failedDefend = false;

	private float phaseOneTimer = Mathf.Infinity;
	private float phaseTwoTimer = Mathf.Infinity;
	private float phaseThreeTimer = Mathf.Infinity;

	public GameObject waveAttack;
	public GameObject earthAttack;
	public GameObject fireAttack;

	public GameObject enemy;
	public GameObject waterAttackSpawnLocation;
	public GameObject earthAttackSpawnLocation;
	public GameObject fireAttackSpawnLocation;

	public Animator animator;

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

					animator.SetBool ("CastEarth", true);
					animator.speed = 1 + (0.4f * gM.getTurnNumber ());
					StartCoroutine (resetAnimations ());

					if(GameObject.FindGameObjectWithTag("WaterAttack"))
					{
						GameObject temp = GameObject.FindGameObjectWithTag ("WaterAttack");
						Destroy (temp, 0.3f );
					}
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					//Success on defend
				} else if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) {
					ClearLeftoverAttacks ();
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				} else if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) {
					ClearLeftoverAttacks ();
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				}
				break;
			case 2:
				if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) {
					Debug.Log ("Defended");

					animator.SetBool ("CounterFire", true);
					animator.speed = 1 + (0.4f * gM.getTurnNumber ());
					StartCoroutine (resetAnimations ());

					if(GameObject.FindGameObjectWithTag("EarthAttack"))
					{
						GameObject temp = GameObject.FindGameObjectWithTag ("EarthAttack");
						Destroy (temp, 0.3f );
					}

					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					//Success on defend
				} else if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) {
					ClearLeftoverAttacks ();
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				} else if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) {
					ClearLeftoverAttacks ();
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				}
				break;
			case 3:
				if (gM.GetComponent<PlayerAttack> ().CheckWaterButton ()) {
					ClearLeftoverAttacks ();
					Debug.Log ("Defended");

					animator.SetBool ("CastWater", true);
					animator.speed = 1 + (0.4f * gM.getTurnNumber ());
					StartCoroutine (resetAnimations ());

					if(GameObject.FindGameObjectWithTag("FireAttack"))
					{
						GameObject temp = GameObject.FindGameObjectWithTag ("FireAttack");
						Destroy (temp, 0.3f);
					}

					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					//Success on defend
				} else if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) {
					ClearLeftoverAttacks ();
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				} else if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) {
					ClearLeftoverAttacks ();
					phaseOneTimer = Mathf.Infinity;
					incomingAttack = false;
					failedDefend = true;
				}
				break;	
			}
		}

		if (phaseOneTimer <= 0.1f) {
			ClearLeftoverAttacks ();
			phaseOneTimer = Mathf.Infinity;
			incomingAttack = false;
			failedDefend = true;
		} 
		else
		{
			Debug.Log ("No");
		}


		phaseOneTimer -= Time.deltaTime;

		PrintText.instance.UpdateText (phaseOneTimer.ToString ("F1"), characterNumber + 1);
	}

	void ClearLeftoverAttacks()
	{
		if(GameObject.FindGameObjectWithTag("EarthAttack"))
		{
			GameObject temp = GameObject.FindGameObjectWithTag ("EarthAttack");
			if(temp)
				Destroy (temp, 1);

			temp = null;

			temp = GameObject.FindGameObjectWithTag ("WaterAttack");
			if(temp)
				Destroy (temp, 1);

			temp = null;

			temp = GameObject.FindGameObjectWithTag ("FireAttack");
			if(temp)
				Destroy (temp, 1);


		}
	}

	void PhaseTwo()
	{
		GetComponent<StateController> ().ShowAttack ();

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
			//Player Anims
			animator.SetBool("CastWater", true);
			StartCoroutine(resetAnimations ());

			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming(1);
			GameObject temp = (GameObject)Instantiate (waveAttack, waterAttackSpawnLocation.transform.position, Quaternion.identity);
			temp.transform.rotation = waterAttackSpawnLocation.transform.rotation;
			temp.GetComponent<Animator> ().speed = 1 + (0.4f * gM.getTurnNumber ());
			GetComponent<PlayerStats> ().updateStats (false, 0);

			Destroy (temp, 6);
		
			phaseTwoTimer = Mathf.Infinity;
			GetComponent<StateController> ().HideRenderer ();
			enemy.GetComponent<StateController> ().ShowDefend ();
			gM.changeTurn ();
		}
		else if (gM.GetComponent<PlayerAttack> ().CheckEarthButton ()) 
		{
			GameObject temp = null;

			animator.SetBool("CastEarth", true);
			StartCoroutine(resetAnimations ());

			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming (2);
			if (earthAttack.name.Contains ("PlayerOne"))
			{
				temp = (GameObject)Instantiate (earthAttack, new Vector3 (earthAttackSpawnLocation.transform.position.x, earthAttackSpawnLocation.transform.position.y + 0.2f, earthAttackSpawnLocation.transform.position.z), Quaternion.identity);
				temp.transform.rotation = earthAttackSpawnLocation.transform.rotation;
			}
			else if (earthAttack.name.Contains ("PlayerTwo"))
			{
				temp = (GameObject)Instantiate (earthAttack, new Vector3 (earthAttackSpawnLocation.transform.position.x, earthAttackSpawnLocation.transform.position.y + 0.2f, earthAttackSpawnLocation.transform.position.z), Quaternion.identity);
				temp.transform.rotation = earthAttackSpawnLocation.transform.rotation;
			}

			Destroy (temp, 5);
			temp.GetComponent<Animator> ().speed = 1 + (0.4f * gM.getTurnNumber ());
			GetComponent<PlayerStats> ().updateStats (false, 1);
			phaseTwoTimer = Mathf.Infinity;
			GetComponent<StateController> ().HideRenderer ();
			enemy.GetComponent<StateController> ().ShowDefend ();
			gM.changeTurn ();
		}
		else if (gM.GetComponent<PlayerAttack> ().CheckFireButton ()) 
		{
			//Player Anims
			animator.SetBool("CastFire", true);
			StartCoroutine(resetAnimations ());

			GameObject temp = null;

			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming (3);
			if (earthAttack.name.Contains ("PlayerOne"))
			{
				temp = (GameObject)Instantiate (fireAttack);
			}
			else if (earthAttack.name.Contains ("PlayerTwo"))
			{
				temp = (GameObject)Instantiate (fireAttack);
			}

			Destroy(temp, 5);

			GetComponent<PlayerStats> ().updateStats (false, 2);
			phaseTwoTimer 	= Mathf.Infinity;
			GetComponent<StateController> ().HideRenderer ();
			enemy.GetComponent<StateController> ().ShowDefend ();
			gM.changeTurn ();
		}

		if (phaseTwoTimer <= 0) 
		{
			enemy.GetComponent<RoundController>().setTypeOfAttackIncoming (-1);
			phaseTwoTimer = Mathf.Infinity;
			GetComponent<StateController> ().HideRenderer ();
			enemy.GetComponent<StateController> ().ShowDefend ();
			gM.changeTurn ();
		}

		phaseTwoTimer -= Time.deltaTime;

		PrintText.instance.UpdateText (phaseTwoTimer.ToString ("F1"), characterNumber + 1);
		
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

		PrintText.instance.UpdateText(phaseThreeTimer.ToString("F1"), characterNumber + 1);
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

		GetComponent<HealthController> ().HealthRemoved ();

		if (enemy.GetComponent<PlayerStats> ().health <= 0) {
			GetComponent<PlayerStats> ().wonGame = true;
		}

		animator.speed = 1;

		GetComponent<PlayerStats> ().updateStats (true);
	}


	IEnumerator resetAnimations()
	{
		yield return new WaitForSeconds (1f);


		animator.SetBool ("CastWater", false);
		animator.SetBool ("CastFire", false);
		animator.SetBool ("CastEarth", false);					
		animator.SetBool ("CounterFire", false);

	}
}

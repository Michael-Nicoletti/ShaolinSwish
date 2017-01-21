using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int MAX_HEALTH = 100;

	public int health;

	// Use this for initialization
	void Start () {
		health = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			//Go to victory screen
		}
	
	}
}

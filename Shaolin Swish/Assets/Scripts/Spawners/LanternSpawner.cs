using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSpawner : MonoBehaviour {

	public int MAX_LANTERNS = 10;

	public GameObject LanternObject;

	List<GameObject> lanterns;

	private int lanternCount;

	// Use this for initialization
	void Start () {

		lanterns = new List<GameObject> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (lanternCount < MAX_LANTERNS)
		{
			GameObject temp;

			temp = (GameObject)Instantiate (LanternObject, this.transform.position, this.transform.rotation);

			lanterns.Add (temp);

			lanternCount++;

		}
		
	}
}

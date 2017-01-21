using UnityEngine;
using System.Collections;

public class PrintHealth : MonoBehaviour {

	TextMesh tM;

	public PlayerStats playerWatch;

	// Use this for initialization
	void Start () {
	
		tM = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {

		tM.text = playerWatch.health.ToString (); 
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrintText : MonoBehaviour {

	TextMesh tM;

	public static PrintText instance;

	// Use this for initialization
	void Start () {

		tM = GetComponent<TextMesh> ();
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateText(string message)
	{
		tM.text = message;
	}
}

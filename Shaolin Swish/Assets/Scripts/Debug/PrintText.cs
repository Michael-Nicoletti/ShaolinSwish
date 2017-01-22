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

	public void UpdateText(string message, int playerColor)
	{
//		if (playerColor == 1)
//		{
//			tM.color = new Color (241, 101, 34);
//		} else if (playerColor == 2)
//		{
//			tM.color = new Color (0, 173, 238);
//		}
		
		tM.text = message;
	}
}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform playerOnePos;
	public Transform playerTwoPos;
	public Transform midPlace;
	public Transform lookAtPoint;
	public Vector3 axis;
	public float camSpeed = 1.0f;

	private float startTime;
	private float journeyLength;

	private int playerSelected = 0;

	private Camera gameCam;

	public static CameraController instance;

	// Use this for initialization
	void Start () {

		gameCam = Camera.main;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (lookAtPoint);
		if (GameManager.instance.getTurnNumber () > 7)
		{
			transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, midPlace.position, camSpeed);
		}
		else if (playerSelected == 0) {
			transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, midPlace.position, camSpeed);
		}
		else if (playerSelected == 1)
		{
			transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, playerOnePos.position, camSpeed);
		}
		else if (playerSelected == 2)
		{
			transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, playerTwoPos.position, camSpeed);
		}



	}

	/// <summary>
	/// Moves the camera between different positions with a lerp.
	/// 0 = Mid
	/// 1 = player One
	/// 2 = player Two
	/// </summary>
	/// <param name="pos">Position.</param>
	public void swapCameraPos(int switchPos)
	{
		playerSelected = switchPos;

		if (switchPos == 0) {
			//transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, midPlace.position, camSpeed);
		}
		else if (switchPos == 1)
		{
			//transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, playerOnePos.position, camSpeed);
		}
		else if (switchPos == 2)
		{
			//transform.position = Vector3.Lerp (gameCam.gameObject.transform.position, playerTwoPos.position, camSpeed);
		}
	}
}

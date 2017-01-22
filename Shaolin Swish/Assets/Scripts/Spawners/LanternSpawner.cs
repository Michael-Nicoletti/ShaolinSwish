using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSpawner : MonoBehaviour {

	public int MAX_LANTERNS = 10;

	public GameObject LanternObject;

	List<GameObject> lanterns;

	private int lanternCount;

	private bool canSpawnLantern = true;

	// Use this for initialization
	void Start () {

		lanterns = new List<GameObject> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (canSpawnLantern)
		{
			StartCoroutine(SpawnLantern ());
			canSpawnLantern = false;
		}
		
	}


	IEnumerator SpawnLantern()
	{
		yield return new WaitForSeconds (2);

		GameObject temp;

		temp = (GameObject)Instantiate (LanternObject, new Vector3(this.gameObject.transform.position.x + (Random.Range(-10, 10)),this.gameObject.transform.position.y,this.gameObject.transform.position.z +(Random.Range(-10, 10))), this.transform.rotation);

		lanterns.Add (temp);

		temp.GetComponent<Rigidbody> ().AddForce (Vector3.up * 100);

		canSpawnLantern = true;

		Destroy (temp, 20);
	
	}
}

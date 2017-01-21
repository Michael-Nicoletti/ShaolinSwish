using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour {

	public bool selected = false;

	public MenuObject up;
	public MenuObject down;
	public MenuObject left;
	public MenuObject right;
	public MenuObject next;

	public Vector3 CamPos;

	public bool needsCooldown = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		if (selected)
//		{
//			Debug.Log(gameObject.name+ " is selected");
//		}

		if (InputParser.GetMenuNext ())
		{
			if (next && selected) {
				if(needsCooldown)
					StartCoroutine (MenuCooldown ());
				next.selected = true;
				this.selected = false;
				ChangeMenu ();
			}
		}

		if (InputParser.GetMenuDown())
		{
			if (down && selected) {
				if(needsCooldown)
					StartCoroutine (MenuCooldown ());
				down.selected = true;
				this.selected = false;
			}
		}

		if (InputParser.GetMenuUp())
		{
			if (up && selected) {
				if(needsCooldown)
					StartCoroutine (MenuCooldown ());
				up.selected = true;
				this.selected = false;
			}
		}

		if (InputParser.GetMenuLeft())
		{
			if (left && selected) {
				if(needsCooldown)
					StartCoroutine (MenuCooldown ());
				left.selected = true;
				this.selected = false;
			}
		}

		if (InputParser.GetMenuRight())
		{
			if (right && selected) {
				if(needsCooldown)
					StartCoroutine (MenuCooldown ());
				right.selected = true;
				this.selected = false;
			}
		}

	}

	void ChangeMenu()
	{
		Camera.main.transform.position = next.CamPos;
	}

	IEnumerator MenuCooldown()
	{
		InputParser.pause = true;
		yield return new WaitForSeconds (0.1f);
		InputParser.pause = false;
	}
}

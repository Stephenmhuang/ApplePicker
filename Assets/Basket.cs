using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;

	// Use this for initialization
	void Start () {
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<GUIText> ();
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	//get current screen position of mouse from input
		Vector3 mousePos2D = Input.mousePosition;

		//camera's z position sets the how far to push the mouse into 3d
		mousePos2D.z = -Camera.main.transform.position.z;

		//convert the point from 2d screen space into 3d game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		//move x pos of basket to x pos of mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter ( Collision coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		int score = int.Parse (scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString ();


		//Track high score
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}

}

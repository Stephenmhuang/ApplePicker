using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	// instantiating apples
	public GameObject applePrefab;

	//speed of apple tree in meters
	public float speed =1f;

	//distance where apple tree turns around
	public float leftAndRightEdge = 10f;

	//chance that the apple tree will change directions
	public float chanceToChanceDirections = 0.1f;

	// rate at which apple tree will be instantiated
	public float secondsBetweenAppleDrops = 1f;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	
	}

	void DropApple() {
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//change direction

		if ( pos.x < -leftAndRightEdge ) {
			speed = Mathf.Abs (speed); //move right
		} else if ( pos.x > leftAndRightEdge ) {
			speed = -Mathf.Abs (speed); //move left
		} 


	

	}
	void FixedUpdate() {

		if (Random.value < chanceToChanceDirections) {
			speed *= -1; //change direction
		}
	}

}

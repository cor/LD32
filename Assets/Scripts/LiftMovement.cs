using UnityEngine;
using System.Collections;

public class LiftMovement : MonoBehaviour {

	public float liftShaftHeight = 27f;
	bool isMovingUp = false;

	float startingYpos = 0f;

	// Use this for initialization
	void Start () {
		startingYpos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (isMovingUp && transform.position.y < startingYpos + liftShaftHeight + Time.deltaTime * 2) {

			transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 2);
		}
	
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == 8) {
			isMovingUp = true;
		}
	}

}

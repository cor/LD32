using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 4.0f;
	public float jumpHeight = 5.0f;
	public string horizontalAxisName = "Horizontal";
	// Use this for initialization
	void Start () {                             
	}
	
	void FixedUpdate () {

		float currentAxisValue = Input.GetAxis(horizontalAxisName);

		if (currentAxisValue > 0) {
			//move right
			transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

		}

		else if (currentAxisValue < 0) {
			//move left
			transform.Translate(Vector2.right * -movementSpeed * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//jump
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
		}
	
	}
}

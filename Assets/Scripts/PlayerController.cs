using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 4.0f;
	public float jumpHeight = 3.0f;
	public string horizontalAxisName = "Horizontal";

	private float currentAxisValue = 0f;

	// Use this for initialization
	void Start () {                             
	}

	void Update () {
		currentAxisValue = Input.GetAxis(horizontalAxisName);
	}
	
	void FixedUpdate () {

		transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * currentAxisValue);

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//jump
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse );

		}
	
	}
}

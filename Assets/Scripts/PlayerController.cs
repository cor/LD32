using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 4.0f;
	public string horizontalAxisName = "Horizontal";
	// Use this for initialization
	void Start () {                             
	}
	
	void FixedUpdate () {

		float currentAxisValue = Input.GetAxis(horizontalAxisName);

		if (currentAxisValue > 0) {
			//move right
			Debug.Log("right" + currentAxisValue);
			transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

		}

		else if (currentAxisValue < 0) {
			//move left
			Debug.Log("left" + currentAxisValue);
			transform.Translate(Vector2.right * -movementSpeed * Time.deltaTime);
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class PizzaHover : MonoBehaviour {

	float startPosition ;
	public PlayerController playerController;

	// Use this for initialization
	void Start () {
		startPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(transform.position.x, startPosition + 0.2f * Mathf.Sin(Time.time));
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == 8) {
			playerController.playerCanShoot = true;
			Debug.Log(playerController.playerCanShoot);
			Destroy(gameObject);
		}
	}
}


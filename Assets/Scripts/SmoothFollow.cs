using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public GameObject target;
	private Vector3 velocity = Vector3.zero;
	public float dampTime = 0.15f;

//	Vector3 deltaPosition

	// Use this for initialization
	void Start () {
//		deltaPosition = transform.position -target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.transform.position);

		Vector3 deltaPosition = target.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
		Vector3 destination = transform.transform.position + deltaPosition;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime); 

	}
}

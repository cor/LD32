using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public GameObject target;

	Vector3 deltaPosition;

	// Use this for initialization
	void Start () {
		deltaPosition = transform.position -target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = target.transform.position + deltaPosition;

	}
}

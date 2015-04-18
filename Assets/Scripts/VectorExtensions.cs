using UnityEngine;
using System.Collections;

public static class VectorExtensions {

	public static Vector2 XY (this Vector3 v) {
		return new Vector2 (v.x, v.y);
	}

}


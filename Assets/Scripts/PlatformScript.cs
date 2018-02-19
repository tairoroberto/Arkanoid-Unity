using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	// Movement Speed
	public float speed = 150;

	void FixedUpdate () {	
		GetComponent<Rigidbody2D>().velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
	}
}

using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;

	// Use this for initialization
	void Start() {
		offset = ball.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update() {
		// Main camera should follow the ball until the ball has gone far enough to the pins
		if (ball && ball.transform.position.z < 1700.0f) {
			follow();
		}
	}

	// Keep track of the ball with main camera
	void follow() {
		this.transform.position = ball.transform.position - offset;
	}
}

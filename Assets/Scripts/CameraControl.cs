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
		if (ball && ball.transform.position.z < 1700.0f) {
			follow();
		}
	}

	void follow() {
		this.transform.position = ball.transform.position - offset;
	}
}

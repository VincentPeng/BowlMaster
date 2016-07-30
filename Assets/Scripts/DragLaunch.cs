using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	float startTime, endTime;
	Vector3 startPos, endPos;
	private float distance = 10.0f;

	// Use this for initialization
	void Start() {
		ball = GetComponent<Ball>();
	}

	public void DragStart() {
		Debug.Log("Pointer down");
		startTime = Time.time;
		startPos = Input.mousePosition;
	}

	public void DragEnd() {
		Debug.Log("Pointer up");
		endTime = Time.time;
		endPos = Input.mousePosition;
		float dragDuration = endTime - startTime;
		float speedX = (endPos.x - startPos.x) / dragDuration;
		float speedY = (endPos.y - startPos.y) / dragDuration;
		Vector3 launchVelocity = new Vector3(speedX, 0, -speedY);
		ball.Launch(launchVelocity);
	}

	//	void Update() {
	//		Debug.Log("in update");
	//		while (Input.touchCount > 0) {
	//			Debug.Log("in loop");
	//			Touch touch = Input.touches[0];
	//			switch (touch.phase) {
	//			case TouchPhase.Began:
	//
	//			case TouchPhase.Moved:
	//				ball.transform.position = new Vector3(touch.position.x, touch.position.y, distance);
	//				break;
	//			default:
	//				break;
	//			}
	//		}
	//	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	float startTime, endTime;
	Vector3 startPos, endPos;
	bool inPlay = false;

	// Use this for initialization
	void Start() {
		ball = GetComponent<Ball>();
	}

	public void MoveBeforeStart(float amount) {
		print("MoveBeforeStart");
		if (inPlay) {
			return;
		}
		ball.transform.position += new Vector3(amount, 0, 0);
	}

	public void DragStart() {
		Debug.Log("Pointer down");
		inPlay = true;
		startTime = Time.time;
		startPos = Input.mousePosition;
		print("start " + startPos.x + " " + startPos.y);
	}

	public void DragEnd() {
		Debug.Log("Pointer up");
		endTime = Time.time;
		endPos = Input.mousePosition;
		float dragDuration = endTime - startTime;
		float speedX = 0.5f * (endPos.x - startPos.x) / dragDuration;
		float speedY = (endPos.y - startPos.y) / dragDuration;
		Vector3 launchVelocity = new Vector3(speedX, 0, speedY);
		ball.Launch(launchVelocity);
		print("end " + endPos.x + " " + endPos.y);
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

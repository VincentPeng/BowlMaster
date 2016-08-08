using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private float startTime, endTime;
	private Vector3 startPos, endPos;
	private bool inPlay = false;

	// Use this for initialization
	void Start() {
		ball = GetComponent<Ball>();
	}

	// Used by the arrows on control panel to adjust the position of ball's start position
	public void MoveBeforeStart(float amount) {
		//print("MoveBeforeStart");
		if (inPlay) {
			return;
		}
		ball.transform.position += new Vector3(amount, 0, 0);
	}

	// Callback by the control panel Event Trigger when it has pointer down event
	public void DragStart() {
		//Debug.Log("Pointer down");
		inPlay = true;
		startTime = Time.time;
		startPos = Input.mousePosition;
		print("start " + startPos.x + " " + startPos.y);
	}


	// Callback by the control panel Event Trigger when it has pointer up event
	// Use mouse displacement / time elapse to decide the velocity vector
	public void DragEnd() {
		//Debug.Log("Pointer up");
		endTime = Time.time;
		endPos = Input.mousePosition;
		float dragDuration = endTime - startTime;
		float speedX = 0.5f * (endPos.x - startPos.x) / dragDuration;
		float speedY = (endPos.y - startPos.y) / dragDuration;
		Vector3 launchVelocity = new Vector3(speedX, 0, speedY);
		ball.Launch(launchVelocity);
	}
}

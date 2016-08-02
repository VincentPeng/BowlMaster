using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public float settleTime = 3.0f;
	public Text PinCounter;

	private Ball ball;
	private float lastPinChangeTime = 0.0f;
	private int lastPinCount = -1;
	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update() {
		PinCounter.text = CountStanding().ToString();
		if (ballEnteredBox) {
			CheckStanding();
		}
	}

	void CheckStanding() {
		int currentStandingPins = CountStanding();
		if (lastPinCount != currentStandingPins) {
			lastPinChangeTime = Time.time;
			lastPinCount = currentStandingPins;
			return;
		}

		if ((Time.time - lastPinChangeTime) > settleTime) {
			PinsHaveSettled();
		}
	}

	// After x seconds(ball have entered the pinSetter already), if Standing pin account stay the same, call this function
	void PinsHaveSettled() {
		print("pins have settled");
		ball.Reset();
		lastPinCount = -1;
		ballEnteredBox = false;
		PinCounter.color = Color.green;
	}

	public int CountStanding() {
		int sum = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				sum++;
			}
		}
		return sum;
	}

	void OnTriggerEnter(Collider other) {
		print("box entered");
		if (other.gameObject.GetComponent<Ball>()) {
			print("Ball entered");
			PinCounter.color = Color.red;
			ballEnteredBox = true;
		}
		CountStanding();
	}

	void OnTriggerExit(Collider other) {
		print("something left");
		if (other.gameObject.GetComponent<Pin>()) {
			print("pin left");
			Destroy(other.gameObject);
		}
//		if (other.gameObject.GetComponent<Ball>()) {
//			print("Ball left");
//			Destroy(other.gameObject);
//		}
	}
}

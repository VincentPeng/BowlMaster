using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public float settleTime = 3.0f;
	public Text pinCounter;
	public float distToRaise = 100.0f;
	public GameObject pinSet;

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
		pinCounter.text = CountStanding().ToString();
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
//		print("pins have settled");
		ball.Reset();
		lastPinCount = -1;
		ballEnteredBox = false;
		pinCounter.color = Color.green;
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

	public void RaisePins() {
		Debug.Log("Raise pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				pin.GetComponent<Rigidbody>().useGravity = false;
				pin.transform.position += new Vector3(0, distToRaise, 0);
			}
		}
	}

	public void LowerPins() {
		Debug.Log("Lower pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				pin.GetComponent<Rigidbody>().useGravity = false;
				pin.transform.position -= new Vector3(0, distToRaise, 0);
			}
		}
	}

	public void ResetPins() {
		Debug.Log("Reset pins");
	}

	public 
	void OnTriggerEnter(Collider other) {
//		print("box entered");
		if (other.gameObject.GetComponent<Ball>()) {
//			print("Ball entered");
			pinCounter.color = Color.red;
			ballEnteredBox = true;
		}
		CountStanding();
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<Pin>()) {
			Destroy(other.gameObject);
		}
	}
}

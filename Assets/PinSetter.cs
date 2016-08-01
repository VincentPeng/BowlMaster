using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text PinCounter;
	bool ballEnteredBox = false;

	// Use this for initialization
	void Start() {
		PinCounter.text = CountStanding().ToString();
	}
	
	// Update is called once per frame
	void Update() {
		PinCounter.text = CountStanding().ToString();
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
		if (other.gameObject.GetComponent<Ball>()) {
			print("Ball left");
			Destroy(other.gameObject);
		}
	}
}

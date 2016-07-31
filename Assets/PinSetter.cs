using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text PinCounter;

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

	void OnTriggerEnter() {
		print("box entered");
		CountStanding();
	}
}

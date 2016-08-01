using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3.0f;

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
		//print(name + " " + IsStanding());
	}

	public bool IsStanding() {
		float tiltX = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.x, 270));
		float tiltZ = Mathf.Abs(transform.eulerAngles.z);
		//print(tiltX + " " + tiltZ);
		if (tiltX < standingThreshold && tiltZ < standingThreshold) {
			return true;
		} else {
			return false;
		}
	}
}

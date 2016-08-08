using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource audioSource;

	// Use this for initialization
	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
		rb.useGravity = false;

	}
	
	// Update is called once per frame
	void Update() {
	
	}


	// Launch the ball with specific velocity
	public void Launch(Vector3 velocity) {
		rb.useGravity = true;
		rb.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}

	// Reset the ball to the start position
	public void Reset() {
		Debug.Log("reseting ball");
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = false;
		transform.position = new Vector3(0, 22, 163);

	}
}

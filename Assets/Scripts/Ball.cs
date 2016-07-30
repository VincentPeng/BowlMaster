using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 velocity;
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

	public void Launch(Vector3 velocity) {
		rb.useGravity = true;
		rb.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}
}

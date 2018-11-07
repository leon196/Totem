using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socler : MonoBehaviour {

	public float delay = 1f;

	private float collisionStart;
	private GameObject collided;

	void Start () {
		
	}
	
	void Update () {
		if (collided && collisionStart + delay < Time.time) {
			GameObject.Destroy(collided.GetComponent<Rigidbody>());
			// collided.GetComponent<Rigidbody>().isKinematic = true;
			collided.transform.parent = transform;
		}
	}

	void OnCollisionEnter (Collision collision) {
		collided = collision.gameObject;
		collisionStart = Time.time;
	}

	void OnCollisionExit (Collision collision) {
		collided = null;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour {

	public SteamVR_Behaviour_Pose pose;
	public float radius = .2f;

	private GameObject grabbed;

	void Start () {
	}	

	void Update () {
		if (grabbed != null) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				grabbed.GetComponent<Entity>().Switch();
			}
			float wheel = Input.GetAxis("Mouse ScrollWheel");
			grabbed.transform.localScale += Vector3.one * wheel * Time.deltaTime * .1f;
		}
	}
	
	public void Grab () {
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		if (colliders.Length > 0) {
			for (int index = 0; index < colliders.Length; ++index) {
				grabbed = colliders[index].transform.parent.gameObject;
				Rigidbody r = grabbed.GetComponent<Rigidbody>();
				if (r != null && grabbed.GetComponent<Socler>() == null) {
					Transform t = grabbed.transform;
					r.isKinematic = true;
					t.parent = transform;
					break;
				}
			}
		}
	}
	
	public void Drop () {
		if (grabbed != null) {
			Rigidbody r = grabbed.GetComponent<Rigidbody>();
			if (r != null) {
				Transform t = grabbed.transform;
				r.isKinematic = false;
				r.AddForce(pose.GetVelocity(), ForceMode.VelocityChange);
				t.parent = null;
			}
			grabbed = null;
		}
	}

	public void Switch () {
		if (grabbed != null) {
			grabbed.GetComponent<Entity>().Switch();
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}

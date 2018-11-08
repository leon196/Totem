using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject prefabCollection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Switch();
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset();
		}
	}

	public void Reset () {
		if (transform.childCount > 0) {
			Transform t = transform.GetChild(0);
			t.localPosition = Vector3.zero;
			t.localRotation = Quaternion.identity;
		}
	}

	public void Switch () {
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		Transform t;
		if (transform.childCount > 0) {
			t = transform.GetChild(0);
			pos = t.position;
			rot = t.rotation;
		}
		foreach (Transform child in transform) {
     GameObject.DestroyImmediate(child.gameObject);
 		}
 		int childCount = prefabCollection.transform.childCount;
 		GameObject instance = GameObject.Instantiate(prefabCollection.transform.GetChild(Random.Range(0, childCount)).gameObject);
 		t = instance.transform;
 		t.parent = transform;
 		t.position = pos;
 		t.rotation = rot;
	}
}

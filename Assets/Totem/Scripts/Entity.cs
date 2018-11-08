using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public GameObject prefabCollection;
	private int index;

	void Start () {
		index = 0;
	}
	
	void Update () {
		
	}

	public void Switch () {
 		int childCount = prefabCollection.transform.childCount;
 		// GameObject prefab = prefabCollection.transform.GetChild(index).gameObject;
 		GameObject.Destroy(transform.GetChild(0).gameObject);
 		GameObject instance = GameObject.Instantiate(prefabCollection.transform.GetChild(index).gameObject);
 		instance.transform.parent = transform;
 		instance.transform.localPosition = Vector3.zero;
 		instance.transform.localRotation = Quaternion.identity;
 		instance.transform.localScale = Vector3.one;
 		// gameObject.GetComponent<MeshFilter>().mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
 		// gameObject.GetComponent<MeshRenderer>().material = prefab.GetComponent<MeshRenderer>().sharedMaterial;
 		index = (index + 1) % childCount;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public GameObject prefabCollection;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void Switch () {
 		int childCount = prefabCollection.transform.childCount;
 		GameObject prefab = prefabCollection.transform.GetChild(Random.Range(0, childCount)).gameObject;
 		gameObject.GetComponent<BoxCollider>().size = prefab.GetComponent<BoxCollider>().size;
 		gameObject.GetComponent<MeshFilter>().mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
 		gameObject.GetComponent<MeshRenderer>().material = prefab.GetComponent<MeshRenderer>().sharedMaterial;
	}
}

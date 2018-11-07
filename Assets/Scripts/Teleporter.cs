using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleporter : MonoBehaviour {

	private SteamVR_PlayArea area;
	private Vector3 hitPosition;
	private RaycastHit hitInfo;
	private LineRenderer lineRenderer;
	private bool hitCollision;
	
	void Start () {
		area = GetComponentInParent<SteamVR_PlayArea>();
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	void Update () {
		hitCollision = Physics.Raycast(transform.position, transform.forward, out hitInfo);
		if (hitCollision) {
			hitPosition = hitInfo.point;
			lineRenderer.enabled = true;
			for (int index = 0; index < lineRenderer.positionCount; ++index) {
				float angle = 2f*Mathf.PI*(float)index/(float)lineRenderer.positionCount;
				lineRenderer.SetPosition(index, new Vector3(Mathf.Cos(angle)*.1f + hitPosition.x, .1f, Mathf.Sin(angle)*.1f + hitPosition.z));
			}
		} else {
			lineRenderer.enabled = false;
		}
	}

	public void Teleport () {
		if (hitCollision) {
			area.transform.position = new Vector3(hitPosition.x, 0f, hitPosition.z);
		}
	}
}

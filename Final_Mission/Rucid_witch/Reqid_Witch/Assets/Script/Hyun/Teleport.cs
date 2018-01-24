using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	public GameObject TeleportMarker;
	public Transform Player;
	public float RayLength = 50f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, RayLength))
		{
			if (hit.collider.CompareTag("Ground"))
			{
				if (!TeleportMarker.activeSelf)
				{
					TeleportMarker.SetActive(true);
				}
				Vector3 point = hit.point;
				point.y += 0.1f;
				TeleportMarker.transform.position = point;
			}
			else
			{
				TeleportMarker.SetActive(false);
			}
		}
	}
}

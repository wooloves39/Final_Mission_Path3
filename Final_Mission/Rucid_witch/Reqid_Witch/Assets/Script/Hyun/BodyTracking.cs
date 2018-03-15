using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking : MonoBehaviour {
	public GameObject tracker;
	private Vector3 pos=Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = tracker.transform.position;
		pos.y = 0;
		gameObject.transform.position = pos;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFall : MonoBehaviour {
	public GameObject waterFall;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(waterFall.transform.position, Vector3.up, 10.0f * Time.deltaTime);
	}
}

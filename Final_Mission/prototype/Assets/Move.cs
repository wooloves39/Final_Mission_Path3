using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public float movespeed = 6.0f;
	private AudioSource test;
	// Use this for initialization
	void Start () {
		test = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			test.Play();
		}
		if (Input.GetKey (KeyCode.A)) {	
			this.transform.Translate (Vector3.left* movespeed* Time.deltaTime,Space.Self);
		}
		if (Input.GetKey (KeyCode.W)) {		
			this.transform.Translate (Vector3.forward * movespeed* Time.deltaTime,Space.Self);

		}
		if (Input.GetKey (KeyCode.S)) {		
			this.transform.Translate (Vector3.back * movespeed* Time.deltaTime,Space.Self);

		}
		if (Input.GetKey (KeyCode.D)) {		
			this.transform.Translate (Vector3.right * movespeed * Time.deltaTime,Space.Self);

		}
		if (Input.GetKey(KeyCode.B))
		{
			Vector3 rotate = new Vector3(0, 90, 0);
			this.transform.Rotate(rotate);
		}
	}
}

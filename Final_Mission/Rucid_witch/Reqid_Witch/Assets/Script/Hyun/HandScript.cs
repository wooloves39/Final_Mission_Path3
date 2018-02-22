using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {
	Animator HandAni;
	// Use this for initialization
	void Start () {
		HandAni = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D))
		{
			HandAni.Play("Fist");
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			HandAni.Play("IndexFingerDown");
		}
		else if (Input.GetKey(KeyCode.W))
		{
			HandAni.Play("IndexFingerUp");
		}
		else if (Input.GetKey(KeyCode.E))
		{
			HandAni.Play("restDown");
		}
		else if (Input.GetKey(KeyCode.R))
		{
			HandAni.Play("restUp");
		}
		else if (Input.GetKey(KeyCode.A))
		{
			HandAni.Play("ThumbDown");
		}
		else if (Input.GetKey(KeyCode.S))
		{
			HandAni.Play("ThumbUp");
		}
		else
		{
			HandAni.Play("Idle");
		}
	}
}

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
		if (Input.GetKey(KeyCode.U))
		{
			HandAni.Play("Fist");
		}
		else if (Input.GetKey(KeyCode.I))
		{
			HandAni.Play("IndexFingerDown");
		}
		else if (Input.GetKey(KeyCode.O))
		{
			HandAni.Play("IndexFingerUp");
		}
		else if (Input.GetKey(KeyCode.P))
		{
			HandAni.Play("restDown");
		}
		else if (Input.GetKey(KeyCode.H))
		{
			HandAni.Play("restUp");
		}
		else if (Input.GetKey(KeyCode.J))
		{
			HandAni.Play("ThumbDown");
		}
		else if (Input.GetKey(KeyCode.K))
		{
			HandAni.Play("ThumbUp");
		}
		else
		{
			HandAni.Play("Idle");
		}
	}
}

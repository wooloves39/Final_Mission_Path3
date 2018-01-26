using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollision : MonoBehaviour {
	private bool touch;
	private void Awake()
	{
		touch = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject==gameObject.GetComponent<TouchCollision>())
		{
			touch = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		touch = false;
	}
	public bool GetTouch() { return touch; }
}

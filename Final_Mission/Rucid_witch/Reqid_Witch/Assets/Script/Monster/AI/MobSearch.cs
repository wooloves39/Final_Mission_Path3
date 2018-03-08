using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSearch : MonoBehaviour {
	Stage5MobAI ai;
	public bool Search = false;
	public Vector3 PlayerPos;
	// Use this for initialization
	void Start () {
		ai = GetComponentInParent<Stage5MobAI>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			Search = true;
			ai.Fight = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			Search = false;
			ai.Fight = false;
		}
	}
}

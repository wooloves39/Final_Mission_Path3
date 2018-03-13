using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	public bool check = false;

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Ground")
		{
			check = true;
		}
	}
}

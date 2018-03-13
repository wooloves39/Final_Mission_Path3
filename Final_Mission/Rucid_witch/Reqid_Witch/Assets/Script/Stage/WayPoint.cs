using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	public bool check = false;
	public bool PlayerIN = false;


	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Ground")
		{
			check = true;
		}
		if (col.tag == "PlayerHit")
		{
			PlayerIN = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "PlayerHit")
		{
			PlayerIN = false;
		}
	}

}

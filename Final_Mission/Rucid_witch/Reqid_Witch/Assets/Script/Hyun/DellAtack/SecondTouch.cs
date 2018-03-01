using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTouch : MonoBehaviour {
	private Teleport teleport;
	// Use this for initialization
	private void Awake()
	{
		teleport = gameObject.transform.parent.parent.parent.parent.GetComponent<Teleport>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			if (teleport.getDelltouch())
			{
				Debug.Log("활 뒷대가리 맞음");
				teleport.setDelltouch(false);
				teleport.setDellcount();
			}
		}
	}
}

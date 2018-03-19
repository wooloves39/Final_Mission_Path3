using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTouch : MonoBehaviour {
	private Teleport teleport;
	private bool firstTouch;
	private AudioSource dellsound;
	private void OnEnable()
	{
		firstTouch = false;
	}
	// Use this for initialization
	private void Awake()
	{
		dellsound = gameObject.transform.parent.GetComponent<AudioSource>();
		teleport = gameObject.transform.parent.parent.parent.parent.GetComponent<Teleport>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("DellAttack"))
		{
			if (!teleport.getDelltouch())
			{
				Debug.Log("활 앞대가리 맞음");
				teleport.setDelltouch(true);
				if (!firstTouch)
				{
					teleport.DellCharging(9.0f);
					dellsound.Play();
					firstTouch = true;
				}
			}
		}
	}
}

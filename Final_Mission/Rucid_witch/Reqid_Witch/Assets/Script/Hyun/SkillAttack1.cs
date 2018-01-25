using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillAttack1 : MonoBehaviour {
	public GameObject LPoint;
	public GameObject RPoint;
	// Use this for initialization
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject==LPoint|| other.gameObject == RPoint)
		{
			LPoint.GetComponent<Image>().material.color = new Color(0, 0, 0);
			RPoint.GetComponent<Image>().material.color = new Color(0, 0, 0);
		}
	}
}

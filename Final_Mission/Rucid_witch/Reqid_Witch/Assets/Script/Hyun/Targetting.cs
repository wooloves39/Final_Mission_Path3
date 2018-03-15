using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour {
	private List<GameObject> TargetMonster=new List<GameObject>();
	private int TargetCount;
	// Use this for initialization
	void Start () {
		TargetCount = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Monster"))
		{
			Debug.Log("Add Mon");
			TargetMonster.Add(other.gameObject);
			TargetCount++;
		}			
	}
	private void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag("Monster"))
		{
			Debug.Log("Del Mon");
			TargetMonster.Remove(other.gameObject);
			TargetCount--;
		}
	}
}

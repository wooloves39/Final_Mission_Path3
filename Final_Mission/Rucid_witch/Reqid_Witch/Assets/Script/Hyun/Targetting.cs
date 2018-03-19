using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
	private List<GameObject> TargetMonster = new List<GameObject>();
	private int TargetCount;
	private GameObject Mytarget;
	private bool firstCheck = false;
	// Use this for initialization
	void Start()
	{
		TargetCount = 0;
	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Monster"))
		{
			Debug.Log("Add Mon");
			TargetMonster.Add(other.gameObject);
			if (!firstCheck)
			{
				firstCheck = true;
				Mytarget = other.gameObject;
			}
			TargetCount++;
		}
	}
	private void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag("Monster"))
		{
			Debug.Log("Del Mon");
			if (Mytarget == other.gameObject)
			{
				firstCheck = false;
				Mytarget = null;
				checkTarget();
			}
			TargetMonster.Remove(other.gameObject);
			TargetCount--;
		}
	}
	private void checkTarget()
	{
		GameObject target = null;
		Vector3 mypos = transform.position;
		for (int i = 0; i < TargetMonster.Capacity; ++i)
		{
			if (target == null)
			{
				target = TargetMonster[0];
			}
			else
			{
				if (Vector3.Distance(mypos, target.transform.position) > Vector3.Distance(mypos, TargetMonster[i].transform.position))
				{
					target = TargetMonster[i];
				}
			}
		}
		Mytarget = target;
	}
	private IEnumerator targetChange()
	{
		Vector3 Stick;
		int index=5;
		while (true)
		{
			Stick = InputManager_JHW.SubJoystick();
			if (Stick.x < 0)
				index = 0;

			if (Stick.x > 0)
				index = 1;
			if (index == 0)
			{

			}
			else
			{

			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}

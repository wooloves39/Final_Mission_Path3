using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NatureCommand : MonoBehaviour
{
	
	GameObject obj;
	Vector3 Destination;
	float ObjSpeed;
	float TimeLimit;
	bool state = false;
	float time = 0.0f;
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent> agent
	}
	public void StateChange(bool check)
	{
		if (check)
			state = true;
		else
			state = false;
	}
	public void NatureMove(MoveMsg msg)
	{
		obj = msg.obj;
		Destination = msg.destination;
		ObjSpeed = msg.Speed;
		TimeLimit = msg.time;
		time = 0.0f;

		StartCoroutine("NMove");
	}

	IEnumerator NMove()
	{
		obj.transform.LookAt(Destination );
		while (true)
		{
			float temp = Time.deltaTime;
			if (time >= TimeLimit)
			{
				break;
			}
			else
				yield return new WaitForSeconds(temp);
		}
	}
}

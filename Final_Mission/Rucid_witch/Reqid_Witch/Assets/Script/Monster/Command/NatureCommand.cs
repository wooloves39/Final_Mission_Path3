using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NatureCommand : MonoBehaviour
{
	GameObject obj;
	Vector3 Destination;
	float ObjSpeed;
	float TimeLimit;
	bool state = false;
	float time = 0.0f;

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
			obj.transform.Translate(Vector3.forward * temp * ObjSpeed,Space.Self);
			time += temp;
			if (state == true)
				break;
			if (time >= TimeLimit)
			{
				break;
			}
			else
				yield return new WaitForSeconds(temp);
		}
	}
}

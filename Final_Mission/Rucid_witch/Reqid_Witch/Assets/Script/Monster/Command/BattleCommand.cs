using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleCommand : MonoBehaviour {

	float TimeLimit;
	float time = 0.0f;
	public float AttackFrame = 0.4f;
	private NavMeshAgent agent;
	Animator ani;

	void Start()
	{
		ani = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}
	public void BattleMove(MoveMsg msg)
	{
		agent.destination = msg.destination;
		agent.speed = msg.Speed;
		TimeLimit = msg.time;
		time = 0.0f;

		StartCoroutine("BMove");
	}
	public void Attack(float T)
	{
		agent.speed = 0;
		TimeLimit = T;
		time = 0.0f;

		StartCoroutine("Att");
	}
	IEnumerator Att()
	{
		float temp = Time.deltaTime;
		while (true)
		{
			if(time >= AttackFrame)
				ani.SetBool("IsAttack", false);
			if (time >= TimeLimit)
			{
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
	IEnumerator BMove()
	{
		while (true)
		{
			float temp = Time.deltaTime;
			if (time >= TimeLimit)
			{
				agent.speed = 0.0f;
				break;
			}
			else
			{
				time += temp;
			}
			yield return new WaitForSeconds(temp);
		}
	}
}

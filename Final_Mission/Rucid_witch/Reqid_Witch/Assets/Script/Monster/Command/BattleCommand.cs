using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleCommand : MonoBehaviour {

	float TimeLimit;
	float time = 0.0f;
	int skill_index = 0;
	public float AttackFrame = 0.4f;
	public float[] SkillFrame;
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
	public void Skill(float T,int n)
	{
		agent.speed = 0;
		TimeLimit = T;
		time = 0.0f;
		skill_index = n;
		StartCoroutine("SkillCoroutine");
	}
	IEnumerator SkillCoroutine()
	{
		float temp = Time.deltaTime;
		while (true)
		{
			switch (skill_index)
			{
				case 1:
					if (time >= SkillFrame[0])
						ani.SetBool("Skill1", false);
					break;
				case 2:
					if (time >= SkillFrame[1])
						ani.SetBool("Skill2", false);
					break;
				case 3:
					if (time >= SkillFrame[2])
						ani.SetBool("Skill3", false);
					break;
				case 4:
					if (time >= SkillFrame[3])
						ani.SetBool("Skill4", false);
					break;
					
			}
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

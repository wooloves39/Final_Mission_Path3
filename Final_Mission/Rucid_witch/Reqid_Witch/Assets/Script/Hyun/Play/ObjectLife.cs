using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLife : MonoBehaviour {
	

	public float Hp;
	public float MaxHp;
	public float Speed;
	public float BattleSpeed;
	public float Range;

	public float Attack;
	public float[] SkillDMG = {0,0,0,0};

	public bool MomentInvincible = false;//순간무적
	public float InvincibleTime = 0.2f;//순간무적 시간
	

	private Animator ani;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (other.gameObject.CompareTag("Attacker"))
		//{
		//	Debug.Log("윽 맞음 ㅠㅠㅠ");
		//	attacker attacker = other.gameObject.GetComponent<attacker>();
		//	Hp=attacker.attack(Hp);
		//}
	}
	private void SendDMG(float dmg)
	{
		Debug.Log("recv");
		if (!MomentInvincible)
		{
			Hp -= dmg;
			StartCoroutine("SetInvincible");
		}
	}
	IEnumerator SetInvincible()
	{
		MomentInvincible = true;
		yield return new WaitForSeconds(InvincibleTime);
		MomentInvincible = false;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLife : MonoBehaviour {
	public int Hp;
	public int MaxHp;
	public float Speed;
	public float BattleSpeed;
	public float Range;
	private void OnTriggerEnter(Collider other)
	{
		//if (other.gameObject.CompareTag("Attacker"))
		//{
		//	Debug.Log("윽 맞음 ㅠㅠㅠ");
		//	attacker attacker = other.gameObject.GetComponent<attacker>();
		//	Hp=attacker.attack(Hp);
		//}
	}
}

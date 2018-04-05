using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour {
	public bool OneHit = false;
	public float Power = 100.0f;

	public bool AreaHit = false;
	public float AreaDmg = 40.0f; // 0~100
	public float AreaTime = 0.5f;

	public bool DotHit = false;
	public float DotDmg = 50.0f;
	public float DotTime = 5.0f;
	public float Cycle = 0.3f;

	public int HitCount = 4;
	private float[] Minus  = { 0,0,0};
	private List<GameObject> ObjList = new List<GameObject>();

	public float[] PowerMemory = { 0,0,0 };

	private void OnEnable()
	{

		PowerMemory[0] = Power;
		PowerMemory[1] = AreaDmg;
		PowerMemory[2] = DotDmg;
	}
	void Start () {
		Minus[0] = (float)(Power / HitCount);
		Minus[1] = (float)(AreaDmg/ HitCount);
		Minus[2] = (float)(DotDmg / HitCount);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Monster")
		{
			ObjList.Add(other.gameObject);
			ObjectLife temp;
			temp = other.GetComponentInParent<ObjectLife>();
			Debug.Log(temp.Hp);
			if (OneHit)
			{
				if (!temp.MomentInvincible)
				{
					Debug.Log("send");
					temp.SendMessage("SendDMG", PowerMemory[0]);
					PowerMemory[0] -= Minus[0];
					if (PowerMemory[0] <= 0.0f)
						this.gameObject.SetActive(false);
				}
			}
			if (AreaHit)
			{
				if (!temp.MomentInvincible)
				{
					StartCoroutine("Area_Skill");
				}
			}
			if (DotHit)
			{
				if (!temp.MomentInvincible)
				{
					StartCoroutine("DotSkill", temp);
				}
			}
			
				
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Monster")
		{
			ObjList.Remove(other.gameObject);
		}
	}
	IEnumerator Area_Skill()
	{
		ObjectLife temp;
		yield return new WaitForSeconds(AreaTime);
		for (int j = 0; j < ObjList.Count; ++j)
		{
			temp = ObjList[j].GetComponentInParent<ObjectLife>();
			temp.SendMessage("SendDMG", PowerMemory[0]);
		}
		PowerMemory[1] = 0;
		this.gameObject.SetActive(false);
	}
	IEnumerator DotSkill(ObjectLife obj)
	{
		float Dmg = PowerMemory[2] / DotTime;
		float time = 0.0f;
		PowerMemory[2] -= Minus[2];
		if (PowerMemory[2] <= 0.0f)
			this.gameObject.SetActive(false);
		while (time <= DotTime)
		{
			obj.SendMessage("SendDMG", Dmg);
			time += Cycle;
			yield return new WaitForSeconds(Cycle);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour {
	public bool OneHit = false;
	public float Power = 50.0f;

	public bool AreaHit = false;
	public float AreaDmg = 40.0f; // 0~100

	public bool DotHit = false;
	public float DotDmg = 50.0f;
	public float DotTime = 5.0f;
	public float Cycle = 0.5f;

	public int HitCount = 4;
	private float[] Minus;
	private List<GameObject> ObjList = new List<GameObject>();

	void Start () {
		Minus[0] = (float)(Power / HitCount);
		Minus[1] = (float)(DotDmg / HitCount);
		Minus[2] = (float)(AreaDmg / HitCount);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Monster")
		{
			for (int i = 0; i < ObjList.Count; ++i)
			{
				if (ObjList[i].gameObject != other.gameObject)
				{
					ObjectLife temp;
					temp = other.GetComponentInParent<ObjectLife>();
					if (OneHit)
					{
						if (temp.MomentInvincible)
						{
							temp.SendMessage("SendDMG", Power);
							Power -= Minus[0];
							if (Power <= 0.0f)
								Destroy(this.gameObject);
						}
					}
					if (AreaHit)
					{
						if (temp.MomentInvincible)
						{
							temp.SendMessage("SendDMG", Power);
							AreaDmg -= Minus[1];
							if (AreaDmg <= 0.0f)
								Destroy(this.gameObject);
						}
					}
					if (DotHit)
					{
						if (temp.MomentInvincible)
						{
							StartCoroutine("DotSkill",temp);
						}
					}
					break;
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
	IEnumerator DotSkill(ObjectLife obj)
	{
		float Dmg = DotDmg / DotTime;
		float time = 0.0f;
		DotDmg -= Minus[2];
		if (DotDmg <= 0.0f)
			Destroy(this.gameObject);
		while(time <= DotTime)
		{
			obj.SendMessage("SendDMG", Dmg);
			time += Cycle;
			yield return new WaitForSeconds(Cycle);
		}
	}
}

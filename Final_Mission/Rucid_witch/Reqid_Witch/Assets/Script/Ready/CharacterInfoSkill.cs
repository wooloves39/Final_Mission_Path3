using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoSkill : MonoBehaviour {
	public List<GameObject> skill;
	public int skillnum;
	void Update()
	{
		for (int i = 0; i < 5; ++i)
		{
			skill[i].SetActive(false);
		}
		if(Singletone.Instance.Myskill[skillnum]>-1)
			skill[Singletone.Instance.Myskill[skillnum]].SetActive(true);
	}
}

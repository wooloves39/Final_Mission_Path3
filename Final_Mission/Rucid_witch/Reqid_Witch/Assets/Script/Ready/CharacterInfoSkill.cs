using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoSkill : MonoBehaviour {
	public List<GameObject> skill;
	public int skillnum;
	void OnEnabled()
	{
		for (int i = 0; i < 5; ++i)
		{
			skill[i].SetActive(false);
		}
		skill[Singletone.Instance.Myskill[skillnum]].SetActive(true);
	}
}

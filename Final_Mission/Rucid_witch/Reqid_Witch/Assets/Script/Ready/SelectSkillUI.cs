using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkillUI : MonoBehaviour
{
	private bool left = false;
	private bool right = false;
	private int RotationSkill = 0;
	public List<GameObject> Skill;
	public SelectMenu_Ready menu;
	private int Select = 3;
	private int stage;

	private int lastChange = 0;
	// Update is called once per frame
	void Start()
	{
		stage = Singletone.Instance.stage;
		StartCoroutine(SkillSet());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			skillChoice(RotationSkill);
		}
		if (InputManager_JHW.BButtonDown())
		{
			menu.SelectMenu = -1;
			menu.confirm = false;
		}
	}
	//스테이지 별로 나눠서 설정이 들어가도록 고치기 (월요일의 현우가)
	IEnumerator SkillSet()
	{
		bool flug = false ;
		while (true)
		{
			if (Select == menu.SelectMenu)
			{

				Vector3 Stick;
				Stick = InputManager_JHW.MainJoystick();
				if (left == false && right == false)
				{
					if (Stick.x < 0)
					{
						flug = true;
						left = true;
						RotationSkill++;
						if (RotationSkill == 5)
							RotationSkill = 0;
						for (int i = 0; i < Skill.Capacity; ++i)
						{
							Skill[i].SetActive(false);
						}
					}
					if (Stick.x > 0)
					{
						flug = true;
						right = true;
						RotationSkill--;
						if (RotationSkill == -1)
						{
							RotationSkill = 4;
						}
					
						for (int i = 0; i < Skill.Capacity; ++i)
						{
							Skill[i].SetActive(false);
						}
					}
				}
				else
				{
					if (flug)
					{
						flug = false;
						StartCoroutine(RotateSkill());
						Skill[RotationSkill].SetActive(true);
					}
				}

			}
			yield return new WaitForSeconds(0.1f);
		}
	}
	IEnumerator RotateSkill()
	{
		int count = 0;
		while (count<10)
		{
			count++;
			if (right)
			{
				this.transform.Rotate(new Vector3(0, 7.2f, 0), Space.Self);
			}
			else if (left)
			{
				this.transform.Rotate(new Vector3(0, -7.2f, 0), Space.Self);
			}
			yield return new WaitForSeconds(0.05f);
		}
		right = left = false;
	}
	void skillChoice(int choiceSkill)
	{

		for (int i = 0; i < 3; ++i)
		{
			if (Singletone.Instance.Myskill[i] == choiceSkill)
				return;
		}
		for (int i = 0; i < 3; ++i)
		{
			if (Singletone.Instance.Myskill[i] == -1)
			{
				Singletone.Instance.Myskill[i] = choiceSkill;
				return;
			}
		}
		Singletone.Instance.Myskill[lastChange] = choiceSkill;
		++lastChange;
		if (lastChange == 3) lastChange = 0;
	}
}

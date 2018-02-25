using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkillUI : MonoBehaviour
{
	public bool check2 = false;
	public bool check = false;
	public int num = 0;
	public int skillnum = 0;
	public int RotationSkill = 0;
	public List<GameObject> Skill;
	public GameObject menu;
	SelectMenu_Ready selectMenu_Ready; 
	public int Select = 4;

	// Update is called once per frame
	void Start()
	{
		selectMenu_Ready = menu.GetComponent<SelectMenu_Ready>();
		StartCoroutine("SkillSet");
	}
	IEnumerator SkillSet()
	{
		while (true)
		{
			if (Select == selectMenu_Ready.SelectMenu)
			{
				Vector3 Stick;
				Stick = InputManager_JHW.MainJoystick();
				if (check == false && check2 == false)
				{
					if (Stick.x < 0)
					{
						num = 0;
						check = false;
						check2 = true;
					}
					if (Stick.x > 0)
					{
						num = 0;
						check = true;
						check2 = false;
					}
					if (InputManager_JHW.AButton())
					{
						bool Button = false;
						int j = 0;
						for (int i = 0; i < 3; ++i)
						{
							if (Singletone.Instance.Myskill[i] == RotationSkill)
							{
								j = i;
								if(j != skillnum)
									Button = true;
							}
							if (Button)
							{
									
								for (int k = j; k < 2; ++k)
								{
									Singletone.Instance.Myskill[k] = Singletone.Instance.Myskill[k + 1]; 
									if (Singletone.Instance.Myskill[k] == -1)
										break;
								}
							}
						}
						if (Button == false)
						{
							if (skillnum >= 2)
							{
								Singletone.Instance.Myskill[0] = Singletone.Instance.Myskill[1];
								Singletone.Instance.Myskill[1] = Singletone.Instance.Myskill[2];
								Singletone.Instance.Myskill[2] = RotationSkill;
							}
							else
							{
								Singletone.Instance.Myskill[skillnum] = RotationSkill;
								skillnum++;
							}

						}
						for (int i = 0; i < 3; ++i)
						{
							Debug.Log(Singletone.Instance.Myskill[i]);
						}
						yield return new WaitForSeconds(0.5f);
					}
					if (InputManager_JHW.BButton())
					{
						selectMenu_Ready.SelectMenu = -1;
						selectMenu_Ready.confirm = false;
						yield return new WaitForSeconds(0.5f);
					}
				}
			
				if (check)
				{
					num++;
					this.transform.Rotate(new Vector3(0, 7.2f, 0), Space.Self);
				
					if (num == 5)
					{
						RotationSkill--;
						if (RotationSkill == -1)
							RotationSkill = 4;
						for (int i = 0; i < 5; ++i)
						{
							Skill[i].SetActive(false);
						}
						Skill[RotationSkill].SetActive(true);
					}
					if (num == 10)
					{
						check = false;
					}
				}
				if (check2)
				{
					num++;
					this.transform.Rotate(new Vector3(0, -7.2f, 0), Space.Self);
				
					if (num == 5)
					{
						RotationSkill++;
						if (RotationSkill == 5)
							RotationSkill = 0;
						for (int i = 0; i < 5; ++i)
						{
							Skill[i].SetActive(false);
						}
						Skill[RotationSkill].SetActive(true);
					}
					if (num == 10)
					{
						check2 = false;
					}
				}
				yield return new WaitForSeconds(0.05f);
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
}

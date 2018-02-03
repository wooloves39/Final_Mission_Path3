using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
	public bool check2 = false;
	public bool check = false;
	public int num = 0;
	public List<GameObject> Skill;

	// Update is called once per frame
	void Start()
	{
		StartCoroutine("SkillSet");
	}
	IEnumerator SkillSet()
	{
		Debug.Log("Skill");
		while (true)
		{
			Vector3 Stick;
			Stick = InputManager_JHW.MainJoystick();
			if (check == false && check2 == false)
			{
				if (Stick.x < 0)
				{
					num = 0;
					check = true;
					check2 = false;
				}
				if (Stick.x > 0)
				{
					num = 0;
					check = false;
					check2 = true;
				}
			}
			
			if (check)
			{
				num++;
				this.transform.Rotate(new Vector3(0, -7.2f, 0), Space.Self);
				Debug.Log("SkillA");
				if(num == 10)
					check = false;
			}
			if (check2)
			{
				num++;
				this.transform.Rotate(new Vector3(0, 7.2f, 0), Space.Self);
				Debug.Log("SkillS");
				if(num == 10)
					check2 = false;
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
}

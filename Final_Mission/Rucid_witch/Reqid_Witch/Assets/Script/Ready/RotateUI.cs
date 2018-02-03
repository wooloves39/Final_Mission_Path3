using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{

	public List<GameObject> Skill;


	// Update is called once per frame
	void Start()
	{
		StartCoroutine("SkillSet");
	}
	IEnumerator SkillSet()
	{
		Debug.Log("Skill");
		bool check = false;
		while (true)
		{
			Vector3 Stick;
			Stick = InputManager_JHW.MainJoystick();
			if (true)
			{
				this.transform.Rotate(new Vector3(0, (float)72 / 10, 0), Space.Self);
				Debug.Log("SkillA");
			}
			if (Stick.x > 0 || Input.GetKey(KeyCode.S))
			{
				this.transform.Rotate(new Vector3(0, (float)-72 / 10, 0), Space.Self);
				Debug.Log("SkillS");
			}
			for (int i = 0; i < 5; ++i)
			{
				if (-36.0f <= Skill[i].transform.rotation.y && Skill[i].transform.rotation.y <= 36.0f)

					if (Skill[i].transform.rotation.y == 0)
						check = true;
			}
			if (check)
				break;
			yield return new WaitForSeconds(0.05f);
		}
	}
}

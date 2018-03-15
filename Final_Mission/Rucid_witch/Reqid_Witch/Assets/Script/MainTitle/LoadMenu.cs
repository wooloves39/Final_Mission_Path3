using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
	public GameObject[] Select;
	public GameObject Main;
	public GameObject Confirm;
	public bool confirm = false;
	int index = 0;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable()
	{
		confirm = false;
		index = 0;
		StartCoroutine(KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (index == 0)
			{
				confirm = true;
				Confirm.SetActive(true);
			}
			if (index == 1)
			{
				confirm = true;
				Confirm.SetActive(true);
			}
			if (index == 2)
			{
				confirm = true;
				Confirm.SetActive(true);
			}
			if (index == 3)
			{
				this.gameObject.SetActive(false);
				Main.SetActive(true);
			}
		}
		if (InputManager_JHW.BButtonDown())
		{
			if (index == 0)
			{
				index = 3;
			}
			if (index == 1)
			{
				index = 3;
			}
			if (index == 2)
			{
				index = 3;
			}
			if (index == 3)
			{
				this.gameObject.SetActive(false);
				Main.SetActive(true);
			}

		}
	}
	IEnumerator KeyPad()
	{
		if (!confirm)
		{
			Vector3 Stick;
			while (this.gameObject.activeInHierarchy)
			{
				//KeyBoard	
				Stick = InputManager_JHW.MainJoystick();

				if (Stick.x > 0)
					if (index != 2 && index != 3)
						index++;

				if (Stick.x < 0)
					if (index != 0 && index != 3)
						index--;

				for (int i = 0; i < Select.Length; ++i)
				{
					Select[i].SetActive(false);
				}
				Select[index].SetActive(true);
				yield return new WaitForSeconds(0.125f);
			}
		}
	}
}
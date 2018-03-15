using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject[] Select;
	public GameObject Load;
	public GameObject Option;
	public GameObject Confirm;
	public bool confirm = false;
	public float timer = 0.0f;
	int index = 0;

	void OnEnable()
	{
		confirm = false;
		timer = 0.0f;
		StartCoroutine(KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (index == 0)
			{
				confirm = true;
				//Confirm.SetActive(true); 새로 시작하냐는 메세지를 써야지..
				SceneManager.LoadScene("Stage0");
			}
			if (index == 1)
			{
				Load.SetActive(true);
				this.gameObject.SetActive(false);
			}
			if (index == 2)
			{
			}//멀티플레이
			if (index == 3)
			{
				Option.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
	IEnumerator KeyPad()
	{
		if (!confirm)
		{
			Vector3 Stick;
			while (this.gameObject.activeInHierarchy == true)
			{
				if (timer < 1.0f)
					timer += Time.deltaTime * 25;
				Stick = InputManager_JHW.MainJoystick();

				if (Stick.z < 0)
					if (index != 3)
						index++;

				if (Stick.z > 0)
					if (index != 0)
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
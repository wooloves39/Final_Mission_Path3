using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Main;
	public GameObject Confirm;
	public bool confirm = false;
	public float timer = 0.0f;
	int index = 0;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable ()
	{
		confirm = false;
		index = 0;
		timer = 0.0f;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		if (!confirm)
		{
			Vector3 Stick;
			while (this.gameObject.activeInHierarchy == true) {
				if (timer < 1.0f)
					timer += Time.deltaTime * 25;
				//KeyBoard	
				Stick = InputManager_JHW.MainJoystick ();
				if (confirm)
				{
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

					if (InputManager_JHW.AButton())
					{
						if (timer > 0.5f)
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

							yield return new WaitForSeconds(0.200f);
						}
					}
					if (InputManager_JHW.BButton())
					{
						if (timer > 0.5f)
						{
							bool chk = false;
							if (index == 0)
							{
								index = 3;
								chk = true;
							}
							if (index == 1)
							{
								index = 3;
								chk = true;
							}
							if (index == 2)
							{
								index = 3;
								chk = true;
							}
							if (index == 3 && !chk)
							{
								index = 0;
							}

							yield return new WaitForSeconds(0.200f);

						}
					}
				}
				yield return new WaitForSeconds (0.125f);
			}
		}
	}
}
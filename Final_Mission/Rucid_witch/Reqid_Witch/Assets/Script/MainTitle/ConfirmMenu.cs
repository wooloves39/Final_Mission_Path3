using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmMenu : MonoBehaviour {
	int index = 1;
	public GameObject[] Select;
	public GameObject main;
	public GameObject load;
	public float timer = 0.0f;
	void OnEnable ()
	{
		index = 1;
		StartCoroutine (KeyPad());
		timer = 0.0f;
	}
	IEnumerator KeyPad(){

		Vector3 Stick;
		while(this.gameObject.activeInHierarchy == true)
		{
			if (timer < 1.0f)
				timer += Time.deltaTime * 25;
			Stick = InputManager_JHW.MainJoystick();

			if (Stick.x < 0)
				index = 0;

			if (Stick.x > 0)
				index = 1;

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);

			if (InputManager_JHW.AButton())
			{
				if (timer > 0.5f)
				{
					if (index == 1)
						SceneManager.LoadScene("Ready");
					if (index == 0)
					{
						main.GetComponent<MainMenu>().confirm = false;
						load.GetComponent<LoadMenu>().confirm = false;
						main.GetComponent<MainMenu>().timer = 0;
						this.gameObject.SetActive (false);
					}
				}
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}

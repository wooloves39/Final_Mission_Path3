using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmMenu : MonoBehaviour {
	int index = 1;
	int cnt = 0;
	public GameObject[] Select;
	public GameObject main;
	public GameObject load;
	void OnEnable ()
	{
		cnt = 0;
		index = 1;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		Vector3 Stick;
		while(this.gameObject.activeInHierarchy == true)
		{
			Stick = InputManager_JHW.MainJoystick();

			if (Stick.x < 0)
				index = 1;

			if (Stick.x > 0)
				index = 0;

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);

			if (InputManager_JHW.AButton() || InputManager_JHW.XButton())
			{
				if (cnt > 0)
				{
					if (index == 1)
						SceneManager.LoadScene("Ready Scene");
					if (index == 0) {
						this.gameObject.SetActive (false);
						main.GetComponent<MainMenu> ().confirm = false;
						load.GetComponent<MainMenu> ().confirm = false;
					}
				}
				cnt++;
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}

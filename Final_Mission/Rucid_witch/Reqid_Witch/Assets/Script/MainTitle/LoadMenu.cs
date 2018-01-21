using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Main;
	public GameObject Confirm;
	public bool confirm = false;
	int index = 0;
	int cnt;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable ()
	{
		confirm = false;
		cnt = 0;
		index = 0;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		if (!confirm) {
			Vector3 Stick;
			while (this.gameObject.activeInHierarchy == true) {
				//KeyBoard	
				Stick = InputManager_JHW.MainJoystick ();
				//vertical = 0.0f;
				//horizental = 0.0f;
				//vertical += Input.GetAxis("LThumbstickY");
				//horizental += Input.GetAxis("RThumbstickX");
				if (Stick.x > 0)
				if (index != 2 && index != 3)
					index++;

				if (Stick.x < 0)
				if (index != 0 && index != 3)
					index--;


				if (Stick.z < 0)
					index = 3;

				if (Stick.z > 0)
					index = 2;

				for (int i = 0; i < Select.Length; ++i) {
					Select [i].SetActive (false);
				}
				Select [index].SetActive (true);
				//KeyBoard - Enter
				if (InputManager_JHW.AButton () || InputManager_JHW.XButton ()) {

					if (cnt > 0) {
						if (index == 0) {
							confirm = true;
							Confirm.SetActive (true);
						}
						if (index == 1) {
							confirm = true;
							Confirm.SetActive (true);
						}
						if (index == 2) {
							confirm = true;
							Confirm.SetActive (true);
						}
						if (index == 3) {
							this.gameObject.SetActive (false);
							Main.SetActive (true);
						}

						yield return new WaitForSeconds (0.250f);
					}
					cnt++;
				}
				yield return new WaitForSeconds (0.125f);
			}
		}
	}
}
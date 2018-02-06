using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Load;
	public GameObject Option;
	public GameObject Confirm;
	public bool confirm = false;
	int cnt;
	int index = 0;

	void OnEnable ()
	{
		confirm = false;
		cnt = 0;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		if (!confirm) {
			Vector3 Stick;
			while (this.gameObject.activeInHierarchy == true) {
				Stick = InputManager_JHW.MainJoystick ();

				if (Stick.z < 0)
				if (index != 3)
					index++;

				if (Stick.z > 0)
				if (index != 0)
					index--;
			
				for (int i = 0; i < Select.Length; ++i) {
					Select [i].SetActive (false);
				}
				Select [index].SetActive (true);

				if (InputManager_JHW.AButton ()|| InputManager_JHW.XButton ()) {
					if (cnt > 0) {
						if (index == 0) {
							confirm = true;
							Confirm.SetActive (true);
						}
						if (index == 1) {
							Load.SetActive (true);
							this.gameObject.SetActive (false);
						}
						if (index == 2) {
						}//멀티플레이
						if (index == 3) {
							Option.SetActive (true);
							this.gameObject.SetActive (false);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject[] Sound;
	public GameObject[] Sound2;
	public GameObject[] Grapic;
	public GameObject[] Box;
	public GameObject[] Box2;
	public GameObject[] GrapicBox;
	public GameObject Main;
	int index = 0;
	int sound = 12;
	int sound2 = 22;
	int grapic = 31;
	int cnt;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable () {
		index = 0;
		cnt = 0;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad()
	{
		Vector3 Stick;
		while (this.gameObject.activeInHierarchy == true)
		{
			Stick = InputManager_JHW.MainJoystick();
			if (index < 2) {
				if (Stick.z > 0)
					index = 0;
			
				if (Stick.z < 0)
					index = 1;
			}
			if (index == 4 && index == 3) {
				if (Stick.z > 0)
					index = 3;
				if (Stick.z < 0)
					index = 4;
			}

			if (11 <= index && index <= 13) {
				if (Stick.x > 0 && index < 13)
					index++;

				if (Stick.x < 0 && index > 11)
					index--;
			}

			if (21 <= index && index <= 23) {
				if (Stick.x > 0 && index < 23)
					index++;

				if (Stick.x < 0 && index > 21)
					index--;
			}
			if (30 <= index && index <= 33) {
				if (Stick.x > 0 && index < 33)
					index++;

				if (Stick.x < 0 && index > 30)
					index--;
			}

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}

			if (index < 5) {
				Select [index].SetActive (true);
				for (int i = 0; i < 3; ++i) {
					Box [i].SetActive (false);
					Box2 [i].SetActive (false);
				}
				for (int i = 0; i < 4; ++i) {
					GrapicBox [i].SetActive (false);
				}
			}

			if (11 <= index && index <=	13) {
				Box [sound - 11].SetActive (true);
			}
			if (21 <= index && index <=	23) {
				Box [sound2 - 21].SetActive (true);
			}
			if (30 <= index && index <=	33) {
				Box [grapic - 30].SetActive (true);
			}

			//KeyBoard - Enter
			if (InputManager_JHW.AButton())
			{
				if (index == 0)
					index = 3;
				
				if (index == 3)
					index = sound;
				if (11 <= index && index <= 13) {
					sound = index;
					for (int i = 0 ; i < 3 ; ++i) {
						Sound [i].SetActive (false);
					}
					Sound [sound - 11].SetActive (true);
				}

				if (index == 4)
					index = sound2;
				if (21 <= index && index <= 23) {
					sound2 = index;
					for (int i = 0 ; i < 3 ; ++i) {
						Sound2 [i].SetActive (false);
					}
					Sound2 [sound2 - 21].SetActive (true);
				}

				if (30 <= index && index <= 33) {
					grapic = index;
					for (int i = 0 ; i < 4 ; ++i) {
						Grapic [i].SetActive (false);
					}
					Grapic [grapic - 30].SetActive (true);
				}
				
				if (index == 1)
					index = grapic;
				
				if (index == 2)
				{
					this.gameObject.SetActive(false);
					Main.SetActive(true);
				}
				yield return new WaitForSeconds(0.250f);
			}
			if (InputManager_JHW.BButton ()) {
				if (index == 0 || index == 1)
					index = 2;
				if (index == 2)
					index = 0;
				if (index == 3 || index == 4)
					index = 0;
				if (11 <= index  || index <= 13)
					index = 3;
				if (21 <= index  || index <= 23)
					index = 4;
				if (30 <= index  || index <= 33)
					index = 1;
				yield return new WaitForSeconds(0.250f);
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}
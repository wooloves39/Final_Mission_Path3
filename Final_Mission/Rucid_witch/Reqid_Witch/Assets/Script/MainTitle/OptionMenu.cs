using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject[] Sound;
	public GameObject[] Box;
	public GameObject Main;
	int index = 0;
	int sound = 11;
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
			//KeyBoard
			//vertical = 0.0f;
			//horizental = 0.0f;
			//vertical += Input.GetAxis("LThumbstickY");
			//horizental += Input.GetAxis("RThumbstickX");
			if (Stick.x>0)
			if (index != 12 && index >= 10)
				index++;
				
			if(Stick.x<0)
				if (index != 10 && index >= 10)
					index--;

			if (Stick.z > 0)
				index = 0;

			if (Stick.z < 0)
				index = 1;

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			if (index < 2) {
				Select [index].SetActive (true);
				Box[0].SetActive (false);
				Box[1].SetActive (false);
				Box[2].SetActive (false);
			}
			if (index == 10) {
				Box[index - 10].SetActive (true);
				Box[1].SetActive (false);
				Box[2].SetActive (false);
			}
			if (index == 11) {
				Box[index - 10].SetActive (true);
				Box[0].SetActive (false);
				Box[2].SetActive (false);
			}
			if (index == 12) {
				Box[index - 10].SetActive (true);
				Box[0].SetActive (false);
				Box[1].SetActive (false);
			}

			//KeyBoard - Enter
			if (InputManager_JHW.AButton() || InputManager_JHW.XButton())
			{
				if (cnt > 0)
				{
					cnt = 0;
					if (index == 10)
					{
						sound = index;
						Sound[index - 10].SetActive(true);
						Sound[1].SetActive(false);
						Sound[2].SetActive(false);
						Box[0].SetActive(false);
						Box[1].SetActive(false);
						Box[2].SetActive(false);
					}
					if (index == 11)
					{
						sound = index;
						Sound[index - 10].SetActive(true);
						Sound[0].SetActive(false);
						Sound[2].SetActive(false);
						Box[0].SetActive(false);
						Box[1].SetActive(false);
						Box[2].SetActive(false);
					}
					if (index == 12)
					{
						sound = index;
						Sound[index - 10].SetActive(true);
						Sound[1].SetActive(false);
						Sound[0].SetActive(false);
						Box[0].SetActive(false);
						Box[1].SetActive(false);
						Box[2].SetActive(false);
					}
					if (index == 0)
						index = sound;
					if (index == 1)
					{
						this.gameObject.SetActive(false);
						Main.SetActive(true);
					}
					yield return new WaitForSeconds(0.250f);
				}
				cnt++;
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}
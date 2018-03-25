﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmMenu : MonoBehaviour {
	int index = 1;
	public GameObject[] Select;
	public GameObject load;
	void OnEnable ()
	{
		index = 1;
		StartCoroutine (KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (index == 1)
				SceneManager.LoadScene("Ready");
			if (index == 0)
			{
				load.GetComponent<LoadMenu>().confirm = false;
				this.gameObject.SetActive(false);
			}
		}
	}
	IEnumerator KeyPad(){

		Vector3 Stick;
		while(this.gameObject.activeInHierarchy == true)
		{
			Stick = InputManager_JHW.MainJoystick();

			if (Stick.x < 0)
				index = 0;

			if (Stick.x > 0)
				index = 1;

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);

		
			yield return new WaitForSeconds(0.125f);
		}
	}
}

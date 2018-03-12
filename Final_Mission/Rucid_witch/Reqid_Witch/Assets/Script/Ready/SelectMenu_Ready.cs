﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectMenu_Ready : MonoBehaviour {

	public GameObject[] ui_arr;
	public GameObject[] Menus;
	public Vector2[] posit_arr;
	public int index = 0;
	public Vector2 myposit = new Vector2(0,1);
	public bool confirm = false;
	public bool move = true;
	public int SelectMenu = -1;
	float timer = 0.0f;
	private int stage;
	public Viberation player;
	void Start(){
		stage = Singletone.Instance.stage;
		//test 
		stage = 1;
		StartCoroutine(KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (!confirm)
			{
				SelectMenu = index;
				confirm = true;
				player.StartCoroutine(Viberation.ViberationCoroutine(0.2f, 0.3f, OVRInput.Controller.RTouch));
				player.StartCoroutine(Viberation.ViberationCoroutine(0.2f, 0.3f, OVRInput.Controller.LTouch));
				ui_arr[SelectMenu].GetComponent<Image>().color = new Color(1, 0, 1) ;
				Menus[SelectMenu].transform.Translate(0, 0, -10);
				Menus[SelectMenu].transform.LookAt(Camera.main.transform);
				Menus[SelectMenu].transform.Rotate(0,180,0);


			}
		}
		if (InputManager_JHW.BButtonDown())
		{
			if (confirm)
			{
				Menus[SelectMenu].transform.rotation = Quaternion.identity;
				Menus[SelectMenu].transform.Translate(0, 0,10);
				
				ui_arr[SelectMenu].GetComponent<Image>().color = new Color(1, 1,1);
				SelectMenu = -1;
				confirm = false;
				player.StartCoroutine(Viberation.ViberationCoroutine(0.1f, 0.1f, OVRInput.Controller.RTouch));
				player.StartCoroutine(Viberation.ViberationCoroutine(0.1f, 0.1f, OVRInput.Controller.LTouch));
			}
		}
		if (InputManager_JHW.RTriggerOn() && InputManager_JHW.LTriggerOn())
		{
			//준비 완료되었냐고 물어보는 거 확인후!!
			SceneManager.LoadScene("Stage0");
		}
	}
	IEnumerator KeyPad()
	{
		
		while (true)
		{
			if (!confirm)
			{
				Vector3 Stick;
				if (move)
				{
					if (timer < 1.0f)
						timer += Time.deltaTime * 25;
					Stick = InputManager_JHW.MainJoystick();

					if (Stick.x > 0)
					{
						if (myposit.x < 2)
							myposit.x++;
					}

					if (Stick.x < 0)
					{
						if (myposit.x > -1)
							myposit.x--;
					}
					if (Stick.z > 0)
					{
						myposit.y = 1;
					}
					if (Stick.z < 0)
					{
						myposit.y = -1;
					}
				}

				if (Vector2.Distance(myposit,new Vector2(-1,1))<0.1f)
					index = 0;
				else if(Vector2.Distance(myposit,new Vector2(0,1))<0.1f)
					index = 0;
				else if (Vector2.Distance(myposit,new Vector2(1,1))<0.1f)
					index = 1;
				else if(Vector2.Distance(myposit,new Vector2(2,1))<0.1f)
					index = 2;
				else if(Vector2.Distance(myposit,new Vector2(-1,-1))<0.1f)
					index = 3;
				else if(Vector2.Distance(myposit,new Vector2(0,-1))<0.1f)
					index = 4;
				else if(Vector2.Distance(myposit,new Vector2(1,-1))<0.1f)
					index = 5;
				else if(Vector2.Distance(myposit,new Vector2(2,-1))<0.1f)
					index = 6;

				for (int i = 0; i < 7; ++i)
				{
					ui_arr[i].SetActive(false);
					if (i == index)
					{
						ui_arr[i].SetActive(true);
						continue;
					}
				}
				yield return new WaitForSeconds(0.05f);
			}
			
			yield return new WaitForSeconds(0.05f);
		}
	}
}

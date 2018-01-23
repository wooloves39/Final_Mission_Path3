﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_mouse : MonoBehaviour
{
	public input_non_instant[] Skills;
	private int[] mySkills;
	private float timer = 0;
	private bool skillon;
	private float skill_timer;
	private int mytype;
	private bool touchOn = false;
	private LaserColl raser;
	// Use this for initialization
	void Start()
	{
		raser = GetComponentInChildren<LaserColl>();
		mytype = 0;
		skill_timer = 0;
		skillon = false;
		//mySkills = Singletone.Instance.skill;
		mySkills = new int[3];
		mySkills[0] = 3;
		mySkills[1] = 2;
		mySkills[2] = 4; //test

	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		//skill이 성립되었을경우 1초간 보여준다. 
		if (skillon == true)
		{
			skill_timer += Time.deltaTime;
			if (skill_timer > 1.0f)
			{
				skill_timer = 0.0f;
				skillon = false;
			}
		}
		
		//마우스 클릭시
		if (touchOn == false && InputManager_JHW.RTriggerOn())
		{
			//skill 오브젝트를 좌표에 맞게 생성한다.
			raser.gameObject.SetActive(true);
			Vector3 pos = transform.position;
			Skills[mySkills[mytype]].transform.position = pos;

			Skills[mySkills[mytype]].transform.rotation = transform.rotation;
			Skills[mySkills[mytype]].gameObject.SetActive(true);
			touchOn = true;
		}
		//마우스를 땟을때, 스킬이 발동했는지 확인한다.
		if (!InputManager_JHW.RTriggerOn())
		{
			raser.gameObject.SetActive(false);
			touchOn = false;
		    Skills[mySkills[mytype]].SkillOn();

		}
	}
	public void Upcount(PointCheck col)
	{
		Skills[mySkills[mytype]].UpCount();
		Skills[mySkills[mytype]].TouchPoint(col);
	}
	public void myType()
	{
		++mytype;
		if (mytype > 2) mytype = 0;
	}
}


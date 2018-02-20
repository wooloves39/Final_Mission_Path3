﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour {
	private bool shot = false;
	private bool del_timer = false;
	private float timer;
	private Vector3 curScale;
	// Use this for initialization

	private void Start()
	{
		timer = new int();
		timer = 0.0f;
		curScale = gameObject.transform.localScale;
	}
	// Update is called once per frame
	private void Update()
	{
		if (shot == true)
		{
			timer += Time.deltaTime;
			if (timer >= 2.0f)
				del_timer = true;
		}
	}
	public void Shooting(bool val)
	{
		shot = val;
	}
	public bool IsShooting() { return shot; }
	public bool IsDelete()
	{
		return del_timer;
	}
	public void Reset()
	{
		shot = false;
		del_timer = false;

		timer = 0.0f;
		gameObject.transform.localScale = curScale;
	}
}

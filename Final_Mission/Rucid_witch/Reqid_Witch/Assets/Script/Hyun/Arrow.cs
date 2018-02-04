using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private bool shot = false;
	private bool del_timer = false;
	private float timer;
	// Use this for initialization
	void Awake () {
		timer = new int();
	}

	// Update is called once per frame
	void Update () {
		if (shot == true)
		{
			timer += Time.deltaTime;
			if (timer >= 5.0f)
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChange : MonoBehaviour {
	public input_mouse Draw_Rtouch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager_JHW.XButtonDown())
		{
			Draw_Rtouch.myType();
		}
	}
}

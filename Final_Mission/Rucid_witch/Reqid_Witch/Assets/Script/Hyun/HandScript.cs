using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
	public Animator LHandAni;
	public Animator RHandAni;
	private PlayerState myState;
	// Use this for initialization
	void Start()
	{
		myState = GetComponent<PlayerState>();
	}

	// Update is called once per frame
	void Update()
	{
		if ((int)myState.GetMyState() < 2)
		{
			if (InputManager_JHW.LTouchHandleOn())
			{
				LHandAni.Play("Fist");
			}
			else
			{
				LHandAni.Play("Idle");
			}
			if (InputManager_JHW.RTouchHandleOn())
			{
				RHandAni.Play("Fist");
			}
			else if (InputManager_JHW.RTriggerOn())
			{
				RHandAni.Play("IndexFingerUp");
			}
			else
			{
				RHandAni.Play("Idle");
			}
		}
		else
		{
			LHandAni.Play("Idle");
			RHandAni.Play("Idle");
		}

		////디버그 상태
		//if (Input.GetKey(KeyCode.U))
		//{
		//	LHandAni.Play("Fist");
		//	RHandAni.Play("Fist");
		//}
		//else if (Input.GetKey(KeyCode.I))
		//{
		//	LHandAni.Play("IndexFingerDown");
		//	RHandAni.Play("IndexFingerDown");
		//}
		//else if (Input.GetKey(KeyCode.O))
		//{
		//	LHandAni.Play("IndexFingerUp");
		//	RHandAni.Play("IndexFingerUp");
		//}
		//else if (Input.GetKey(KeyCode.P) )
		//{
		//	LHandAni.Play("restDown");
		//	RHandAni.Play("restDown");
		//}
		//else if (Input.GetKey(KeyCode.H))
		//{
		//	LHandAni.Play("restUp");
		//	RHandAni.Play("restUp");
		//}
		//else if (Input.GetKey(KeyCode.J))
		//{
		//	LHandAni.Play("ThumbDown");
		//	RHandAni.Play("ThumbDown");
		//}
		//else if (Input.GetKey(KeyCode.K))
		//{
		//	LHandAni.Play("ThumbUp");
		//	RHandAni.Play("ThumbUp");
		//}
		//else
		//{
		//	LHandAni.Play("Idle");
		//	RHandAni.Play("Idle");
		//}
	}
}

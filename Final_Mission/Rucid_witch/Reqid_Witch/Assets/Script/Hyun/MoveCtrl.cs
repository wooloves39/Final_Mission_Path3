using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour {
	public enum MoveType
	{
		WAY_POINT,
		LOOK_AT,
		DAYDREAM
	}
	public MoveType moveType;

	public float speed = 1.0f;
	public float damping = 3.0f;

	private Transform tr;
	private Transform camTr;
	private CharacterController cc;
	private Transform[] points;
	private int nextIdx = 1;
	//public bool move = false;
	//바꿔야 할 여지가 있음
	public static bool isStopped = false;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		camTr = Camera.main.GetComponent<Transform>();
		cc = GetComponent<CharacterController>();
	//	points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isStopped) return;
		switch (moveType)
		{
			case MoveType.WAY_POINT:
				MoveWayPoint();
				break;
			case MoveType.LOOK_AT:
				MoveLookAt();
				break;
			case MoveType.DAYDREAM:
				MoveTouchPad();
				break;
		}
	}
	void MoveWayPoint()
	{
		Vector3 direction = points[nextIdx].position - tr.position;
		Quaternion rot = Quaternion.LookRotation(direction);
		tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

		tr.Translate(Vector3.forward * Time.deltaTime * speed);
	}
	void MoveLookAt()
	{
		Vector3 dir = camTr.TransformDirection(Vector3.forward);
		cc.SimpleMove(dir * speed);
	}
	//우리 방식
	void MoveTouchPad()
	{
		Vector3 touchDir = InputManager_JHW.MainJoystick();
		//if ((touchDir.magnitude > 0.0f) && !move)
			if (touchDir.magnitude>0.0f)
		{
			Vector3 camdir = camTr.TransformDirection(Vector3.forward);
			Vector3 dir = camdir + touchDir;
			dir.Normalize();
			Vector3 moveDir = camTr.TransformDirection(dir);
			//transform.position += moveDir * 2;
			//move = true;
			cc.SimpleMove(moveDir * speed);
		}
		//else move = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("WAY_POINT"))
		{
			nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
		}
	}
}

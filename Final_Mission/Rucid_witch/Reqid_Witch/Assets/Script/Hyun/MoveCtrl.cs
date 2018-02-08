using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
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
	//private Coroutine moveCoroutine;
	// Use this for initialization
	void Start()
	{
		tr = GetComponent<Transform>();
		camTr = Camera.main.GetComponent<Transform>();
		cc = GetComponent<CharacterController>();
		//	points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
		//moveCoroutine=StartCoroutine(MoveControll());

	}

	// Update is called once per frame
	void Update()
	{
		if (isStopped) {
			//StopCoroutine(moveCoroutine);
			return;
		}
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
		if (InputManager_JHW.BButton())
		{
			turnBack();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			OVRPlugin.rotation = false;
			//OVRPlugin.
		}
	}
	private IEnumerator MoveControll()
	{
		Vector3 touchDir = InputManager_JHW.MainJoystick() * 2;
		if (touchDir.magnitude > 0.0f)
		{
			Vector3 camdir = camTr.TransformDirection(Vector3.forward);
			Vector3 dir = camdir + touchDir;
			dir.Normalize();
			Vector3 moveDir = camTr.TransformDirection(dir);
			cc.SimpleMove(moveDir * 50.0f);
			yield return new WaitForSeconds(0.5f);
		}
		else
		{
			yield return 0;
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
		Vector3 touchDir = InputManager_JHW.MainJoystick() * 2;
		if (touchDir.magnitude > 0.0f)
		{
			Vector3 camdir = camTr.TransformDirection(Vector3.forward);
			Vector3 dir = camdir + touchDir;
			dir.Normalize();
			Vector3 moveDir = camTr.TransformDirection(dir);
			cc.SimpleMove(moveDir * speed);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("WAY_POINT"))
		{
			nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
		}
	}
	private void turnBack()
	{
		Vector3 pos = Vector3.zero;
		if (gameObject.transform.rotation.y == 0)
		{
			pos.y = 180;
		}
		else if (gameObject.transform.rotation.y == 180)
		{
			pos.y = 0;
		}
		gameObject.transform.rotation = Quaternion.Euler(pos);
	}
}

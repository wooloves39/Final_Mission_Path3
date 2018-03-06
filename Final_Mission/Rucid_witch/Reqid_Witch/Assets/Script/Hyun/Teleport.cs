﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	//0이 왼손 1이 오른손
	public GameObject[] Hands;


	//#0번 공격
	private TouchCollision[] AzuraHands;
	public GameObject AzuraBall;

	//#2번 공격
	public GameObject Violin;
	public GameObject Fiddle_Bow;
	public DellHeadTracker HeadTracker;
	private int Dellcount = 0;
	private bool DellTouch = false;
	//#1,3번 공격
	public GameObject[] TeleportMarker;

	//#4번 공격 다른 공격방식과 다르게 메모리 풀을 활용한다 최대 5발!
	public GameObject ArrowPrefab;
	MemoryPool pool = new MemoryPool();
	GameObject[] Arrow;


	public float RayLength = 50f;
	private Coroutine currentCorutine;
	private bool flug = false;
	private Transform camTr;
	private Quaternion MarkerRotate;
	private PlayerState MyState;
	private Viberation PlayerViberation;
	// Use this for initialization
	private void Awake()
	{
		MyState = GetComponent<PlayerState>();
		PlayerViberation = GetComponent<Viberation>();
		camTr = Camera.main.transform;
		MarkerRotate = TeleportMarker[0].transform.rotation;
		AzuraHands = new TouchCollision[2];
		AzuraHands[0] = Hands[0].GetComponent<TouchCollision>();
		AzuraHands[1] = Hands[1].GetComponent<TouchCollision>();
		input_mouse typecheck = GetComponentInChildren<input_mouse>();
		if (typecheck.IsHaveSkill(4))
		{
			int poolCount = 5;
			pool.Create(ArrowPrefab, poolCount);
			Arrow = new GameObject[poolCount];
			for (int i = 0; i < Arrow.Length; ++i)
				Arrow[i] = null;
		}
	}
	private void OnApplicationQuit()
	{
		pool.Dispose();
	}
	// Update is called once per frame
	void Update()
	{ 
		if (InputManager_JHW.LTriggerOn() && InputManager_JHW.RTriggerOn())
		{
			if (MyState.GetMyState() == PlayerState.State.Nomal)
			{
				MyState.SetMyState(PlayerState.State.Attack);
				if (currentCorutine == null)
				{
					flug = true;
					switch (input_mouse.curType)
					{
						case 0://아즈라 공격 형태 기를 모으는 형태, 오큘러스 터치의 충돌에서 출발하여 양손을 벌릴때 점차 커지며 방출
							{
								currentCorutine = StartCoroutine(AzuraControll());
							}
							break;
						case 1://전격 공격, 총알 발사 형태, 몬스터를 타겟하여 전격을 발사 형태, 저격 된 상태에서 기를 모아 방출
							{
								currentCorutine = StartCoroutine(BeejaeControll());
							}
							break;
						case 2://바이올린 상태 전체 공격 위주, 한정된 시간에 여러번 좌우 이동을 통해 차징 공격
							{
								currentCorutine = StartCoroutine(DellControll());
							}
							break;
						case 3:// 양 컨트롤러의 포인터가 맞춰졌을대 발동, 트리거를 계속 on하면 기를 모아 방출 베르베시
							{
								currentCorutine = StartCoroutine(VerbaseControll());
							}
							break;
						case 4:// 화살의 형태 화살을 장전한채로 트리거를 누르고 있을 시 기를 모아 방출
							{
								currentCorutine = StartCoroutine(SeikwanControll());
							}
							break;

					}
				}
			}
		}
		else if ((!InputManager_JHW.RTriggerOn() && !InputManager_JHW.LTriggerOn()) && flug) 
		{
			
			flug = false;
			MyState.SetMyState(PlayerState.State.Nomal);
			SettingOff();
			
		}
		if(MyState.GetMyState() == PlayerState.State.ChargingOver)
		{
			SettingOff();
		}
		if (input_mouse.curType == 4)
		{
			for (int i = 0; i < Arrow.Length; ++i)
			{
				if (Arrow[i])
				{
					if (Arrow[i].GetComponent<Arrow>())
					{
						if (Arrow[i].GetComponent<Arrow>().IsDelete())
						{
							Arrow[i].GetComponent<Arrow>().resetArrow();
							pool.RemoveItem(Arrow[i]);
							Arrow[i] = null;
						}
						//어떤 조건에 의거 Arrow삭제
					}
				}
			}
		}
	}
	private IEnumerator BeejaeControll()
	{
		//왼손
		while (flug)
		{
			Ray ray = new Ray(Hands[0].transform.position, Hands[0].transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, RayLength))
			{
				if (!TeleportMarker[0].activeSelf)
				{
					TeleportMarker[0].SetActive(true);
				}
				Vector3 point = hit.point;
				point.y += 0.2f;
				TeleportMarker[0].transform.LookAt(camTr.position);
				TeleportMarker[0].transform.Rotate(90, 0, 0);
				TeleportMarker[0].transform.position = point;

			}
			//오른손
			ray = new Ray(Hands[1].transform.position, Hands[1].transform.forward);
			if (Physics.Raycast(ray, out hit, RayLength))
			{
				if (!TeleportMarker[1].activeSelf)
				{
					TeleportMarker[1].SetActive(true);
				}
				Vector3 point = hit.point;
				point.y += 0.2f;
				TeleportMarker[1].transform.LookAt(camTr.position);
				TeleportMarker[1].transform.Rotate(90, 0, 0);
				TeleportMarker[1].transform.position = point;
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
	private IEnumerator AzuraControll()
	{
		Vector3 AttackPoint = (AzuraHands[0].transform.position + AzuraHands[1].transform.position) / 2;
		bool instance = false;
		float distance = 0.0f;
		while (flug)
		{
			if (!instance && (AzuraHands[0].GetTouch() || AzuraHands[1].GetTouch()))
			{
				instance = true;
				AzuraBall.SetActive(true);
				AttackPoint += Camera.main.transform.forward * 0.1f;
				AzuraBall.transform.position = AttackPoint;
				MyState.SetMyState(PlayerState.State.Charging,5.0f);
			}
			if (instance)
			{
				float handDis = Vector3.Distance(Hands[0].transform.position, Hands[1].transform.position);
				if (handDis > distance)
				{
					distance = handDis;
					Vector3 Azura = new Vector3(distance * 3.0f, distance * 3.0f, distance * 3.0f);
					AzuraBall.transform.localScale = Azura;
				}

			}
			//yield return null;
			yield return new WaitForSeconds(0.03f);
		}
	}
	private IEnumerator VerbaseControll()
	{
		//왼손
		while (flug)
		{
			Ray ray = new Ray(Hands[0].transform.position, Hands[0].transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, RayLength))
			{
				if (hit.collider.CompareTag("Ground"))
				{
					if (!TeleportMarker[0].activeSelf)
					{
						TeleportMarker[0].SetActive(true);
					}
					Vector3 point = hit.point;
					point.y += 0.2f;
					TeleportMarker[0].transform.position = point;
				}
			}
			//오른손
			ray = new Ray(Hands[1].transform.position, Hands[1].transform.forward);
			if (Physics.Raycast(ray, out hit, RayLength))
			{
				if (hit.collider.CompareTag("Ground"))
				{
					if (!TeleportMarker[1].activeSelf)
					{
						TeleportMarker[1].SetActive(true);
					}
					Vector3 point = hit.point;
					point.y += 0.2f;
					TeleportMarker[1].transform.position = point;
				}
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
	private IEnumerator SeikwanControll()
	{
		bool instance = false;
		float distance = 0.0f;
		Vector3 Seikwan = ArrowPrefab.transform.localScale;
		int ArrowNum = new int();
		GameObject[] ArrowBody = new GameObject[3];//애로우 스케일 조정에서 활용될여지있음
												   //왼손
		while (flug)
		{
			if ((!instance && (AzuraHands[0].GetTouch() || AzuraHands[1].GetTouch())) &&
				(InputManager_JHW.LTriggerOn() && InputManager_JHW.RTriggerOn())
				)
			{
				instance = true;
				for (int i = 0; i < Arrow.Length; ++i)
				{
					if (Arrow[i] == null)
					{
						ArrowNum = i;
						Arrow[i] = pool.NewItem();
						Arrow[i].transform.position = Hands[0].transform.position;
						Rigidbody r = Arrow[i].GetComponent<Rigidbody>();
						r.useGravity = false;
						r.velocity = new Vector3(0, 0, 0);
						break;
					}
					//5발 다쏘고 난다음도 생각해야함
				}
				MyState.SetMyState(PlayerState.State.Charging,5.0f);
			}
			else if (instance)
			{
				float handDis = Vector3.Distance(Hands[0].transform.position, Hands[1].transform.position);
				if ((!InputManager_JHW.RTriggerOn() && InputManager_JHW.LTriggerOn()))
				{
					if (!Arrow[ArrowNum].GetComponent<Arrow>().IsShooting())
					{
						Rigidbody r = Arrow[ArrowNum].GetComponent<Rigidbody>();
						Vector3 Arrowforward = Arrow[ArrowNum].transform.forward;

						r.velocity = Arrowforward * 40f * handDis;
						Arrow[ArrowNum].GetComponent<Arrow>().Shooting(true);
						//임시 코드
						Arrow[ArrowNum].GetComponent<attacker>().SetDamege(10);
						instance = false;
						distance = 0.0f;
					}
				}
				else
				{
					Vector3 ArrowPos = (Hands[0].transform.position + Hands[1].transform.position) / 2;
					Vector3 LookAtpos = Hands[0].transform.position;
					if (!MyState.IsBack())
					{
						LookAtpos.z -= 0.055f;
					}
					else
					{
						LookAtpos.z += 0.055f;
					}
					ArrowPos += Hands[0].transform.forward * 0.05f;
					Arrow[ArrowNum].transform.LookAt(LookAtpos);
					Arrow[ArrowNum].transform.position = ArrowPos;

					if (handDis > distance)
					{
						distance = handDis;
						Seikwan.z = distance * 10;
						Arrow[ArrowNum].transform.localScale = Seikwan;
					}
				}
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
	private IEnumerator DellControll()
	{
		bool instance = false;
		while (flug)
		{
			if (!instance)
			{
				Violin.SetActive(true);
				Fiddle_Bow.SetActive(true);
				instance = true;
			}
			else
			{
				if (HeadTracker.getHeadOn())
				{
					Debug.Log(Dellcount);
				}
			}

			yield return new WaitForSeconds(0.03f);
		}

	}
	public int getDellcount() { return Dellcount; }
	public bool getDelltouch() { return DellTouch; }
	public void setDellcount(int count) { Dellcount += count; }
	public void setDellcount() { ++Dellcount; }
	public void setDelltouch(bool val) { DellTouch = val; }
	public void DellCharging()
	{
		MyState.SetMyState(PlayerState.State.Charging, 9.0f);
	}
	private void SettingOff()
	{
		if (currentCorutine != null)
		{
			StopCoroutine(currentCorutine);
		}
		switch (input_mouse.curType)
		{
			case 0://아즈라 공격 형태 기를 모으는 형태, 오큘러스 터치의 충돌에서 출발하여 양손을 벌릴때 점차 커지며 방출
				{
					AzuraBall.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
					AzuraBall.SetActive(false);
				}
				break;
			case 1://전격 공격, 총알 발사 형태, 몬스터를 타겟하여 전격을 발사 형태, 저격 된 상태에서 기를 모아 방출
				{
					TeleportMarker[0].transform.rotation = MarkerRotate;
					TeleportMarker[1].transform.rotation = MarkerRotate;
					TeleportMarker[0].SetActive(false);
					TeleportMarker[1].SetActive(false);
				}
				break;
			case 2://바이올린 상태 전체 공격 위주, 한정된 시간에 여러번 좌우 이동을 통해 차징 공격
				{
					DellTouch = false;
					Dellcount = 0;
					Violin.SetActive(false);
					Fiddle_Bow.SetActive(false);
				}
				break;
			case 3:// 양 컨트롤러의 포인터가 맞춰졌을대 발동, 트리거를 계속 on하면 기를 모아 방출
				{
					TeleportMarker[0].SetActive(false);
					TeleportMarker[1].SetActive(false);
				}
				break;
			case 4:// 화살의 형태 화살을 장전한채로 트리거를 누르고 있을 시 기를 모아 방출
				{
					for (int i = 0; i < Arrow.Length; ++i)
					{
						if (Arrow[i])
						{
							if (Arrow[i].GetComponent<Arrow>())
							{
								if (!Arrow[i].GetComponent<Arrow>().IsShooting())
								{
									Arrow[i].GetComponent<Arrow>().resetArrow();
									pool.RemoveItem(Arrow[i]);
									Arrow[i] = null;
								}
								//어떤 조건에 의거 Arrow삭제
							}
						}
					}
				}
				break;
		}
		currentCorutine = null;
	}
}
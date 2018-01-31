using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	//0이 왼손 1이 오른손
	public GameObject[] Hands;


	//#1번 공격
	private TouchCollision[] AzuraHands;



	//#3번 공격
	public GameObject[] TeleportMarker;


	public float RayLength = 50f;
	private Coroutine currentCorutine;
	private bool flug = false;
	// Use this for initialization
	private void Awake()
	{
		AzuraHands = new TouchCollision[2];
		AzuraHands[0] = Hands[0].GetComponent<TouchCollision>();
		AzuraHands[1] = Hands[1].GetComponent<TouchCollision>();
	}

	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.LTriggerOn() && InputManager_JHW.RTriggerOn())
		{
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

						}
						break;
					case 2://바이올린 상태 전체 공격 위주, 한정된 시간에 여러번 좌우 이동을 통해 차징 공격
						{

						}
						break;
					case 3:// 양 컨트롤러의 포인터가 맞춰졌을대 발동, 트리거를 계속 on하면 기를 모아 방출
						{
							currentCorutine = StartCoroutine(PointControll());
						}
						break;
					case 4:// 화살의 형태 화살을 장전한채로 트리거를 누르고 있을 시 기를 모아 방출
						{

						}
						break;

				}
			}
		}
		else
		{
			flug = false;
			if (currentCorutine != null)
				StopCoroutine(currentCorutine);
			switch (input_mouse.curType)
			{
				case 0://아즈라 공격 형태 기를 모으는 형태, 오큘러스 터치의 충돌에서 출발하여 양손을 벌릴때 점차 커지며 방출
					{

					}
					break;
				case 1://전격 공격, 총알 발사 형태, 몬스터를 타겟하여 전격을 발사 형태, 저격 된 상태에서 기를 모아 방출
					{
						TeleportMarker[0].SetActive(false);
						TeleportMarker[1].SetActive(false);
					}
					break;
				case 2://바이올린 상태 전체 공격 위주, 한정된 시간에 여러번 좌우 이동을 통해 차징 공격
					{

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

					}
					break;
			}

			currentCorutine = null;
		}
	}
	private IEnumerator PointControll()
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
			yield return new WaitForSeconds(0.01f);
		}
	}
	private IEnumerator AzuraControll()
	{
		bool instance = false;
		float distance = 0.0f;
		while (true)
		{
			if (!instance && (AzuraHands[0].GetTouch() || AzuraHands[1].GetTouch()))
			{
				instance = true;
				Debug.Log("스킬 생성");
			}
			if (instance)
			{
				float handDis = Vector3.Distance(Hands[0].transform.position, Hands[1].transform.position);
				if (handDis < distance)
				{
					distance = handDis;
					Debug.Log("차징!");
				}

			}
			yield return null;
			//yield return new WaitForSeconds(0.5f);
		}
	}
	private IEnumerator BeeJaeControll()
	{
		//왼손
		Ray ray = new Ray(Hands[0].transform.position, Hands[0].transform.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, RayLength))
		{
			if (hit.collider.CompareTag("Monster"))
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
			if (hit.collider.CompareTag("Monster"))
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
		yield return new WaitForSeconds(0.5f);
	}
}
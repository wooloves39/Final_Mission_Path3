using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5MobAI: MonoBehaviour {
	MoveMsg msg;
	public int[] BasicPeace;
	public int[] BasicBattle;
	NatureCommand NCommand;
	Animator ani;

	public float Time_Nature_Stop;		//0
	public float Time_Nature_Move;		//1
	public float Time_Nomal_StopMotion;	//2(Idle)
	public float Time_Nomal_MoveWay;	//3 사용자 지정위치로 이동(미구현)

	public float Time_Taget_Search;		//10
	public float Time_Battle_Move;		//11
	public float Time_Normal_Attack;	//12

	public bool Delay = false;
	public bool Fight = true;//false;

	Queue Battle = null;
	Queue Peace = null;
	void Start()
	{
		ani = GetComponent<Animator>();
		NCommand = GetComponent<NatureCommand>();

		msg = new MoveMsg();
		msg.obj = this.gameObject;
		msg.destination = new Vector3(0,0,0);
		msg.Speed = 4.0f;


		Battle = new Queue();
		Peace = new Queue();
		for (int i = 0; i<BasicPeace.Length ; ++i)
			Peace.Enqueue (BasicPeace [i]);
		for (int i = 0; i<BasicBattle.Length ; ++i)
			Battle.Enqueue (BasicBattle [i]);
		//while (Peace.Count > 0) {
		//	Debug.Log (Peace.Dequeue ());
		//}

		StartCoroutine("AISearching");
	}
	IEnumerator AISearching(){
		int num = 0;
		float time = 1.0f;
		//평화
		while (true) 
		{
			if (Fight == false) 
			{
				while (Peace.Count < 2) 
				{
					num = getRandom (0, 3);
					Peace.Enqueue (num);
				}
			}
			//전투
			else 
			{
				while (Battle.Count < 2)
				{
					num = getRandom (10, 13);
					Battle.Enqueue (num);
				}
			}

			if(!Fight)
				num = (int)Peace.Dequeue ();//동작 처리시에 큐서 빠져나감
			else
				num = (int)Battle.Dequeue ();//동작 처리시에 큐서 빠져나감
			
			//동작 딜레이
			Debug.Log(num);
			string temp;
			AITree.Instance.AIDic.TryGetValue(num,out temp);
			Debug.Log(temp);
			switch (num) 
			{
				case 0:
					{
						ani.SetBool("Stop", true);
						ani.SetBool("IsMove", false);
						ani.SetBool("IsAttack", false);
						time = Time_Nature_Stop;
						break;
					}
				case 1:
					{
						ani.SetBool("Stop", false);
						ani.SetBool("IsMove", true);
						ani.SetBool("IsAttack", false);
						time = Time_Nature_Move;
						msg.time = time;
						NCommand.NatureMove(msg);	
						break;
					}
				case 2:
					{
						ani.SetBool("Stop", false);
						ani.SetBool("IsMove", false);
						ani.SetBool("IsAttack", false);
						time = Time_Nomal_StopMotion;
						break;
					}
				case 3:
					{
						time = Time_Nomal_MoveWay;
						break;
					}
				case 10:
					{
					time = Time_Taget_Search;
					break;
					}
				case 11:
					{
						time = Time_Battle_Move;
						break;
					}
				case 12:
					{
						time = Time_Normal_Attack;
						break;
					}
			default:
				time = 1.0f;
				break;
			}

			yield return new WaitForSeconds (time);
		}
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}

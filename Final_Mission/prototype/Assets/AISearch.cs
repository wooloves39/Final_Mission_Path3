using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AISearch: MonoBehaviour 
{
	public int[] BasicPeace;
	public int[] BasicBattle;

	public float Time_Move;
	public float Time_Nomal_Stop;
	public float Time_Nomal_Motion;
	public float Time_Normal_Attack;
	public float Time_Normal_Skill1;
	public float Time_Normal_Skill2;
	public float Time_Normal_Skill3;
	public float Time_Normal_Skill4;
	public float Time_Special_Skill1;
	public float Time_Special_Skill2;
	public float Time_Special_Skill3;
	public float Time_Cure1;
	public float Time_Cure2;
	public float Time_Cure3;
	public float Time_Buff1;
	public float Time_Buff2;
	public float Time_Buff3;

	bool Delay = false;
	bool Fight = false;

	Queue Battle = null;
	Queue Peace = null;
	void Start()
	{
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
		float time = 0.0f;
		//평화
		while (true) {
			if (Fight == false) 
			{
				while (Peace.Count < 2) 
				{
					num = getRandom (0, 3);
					Peace.Enqueue (num);
				}
				num = (int)Peace.Dequeue ();
			}
		//전투
			else 
			{
				if (Delay != true) 
				{
					num = getRandom (0, 3);
					while (Battle.Count < 2)
					{
						switch (num) 
						{
						case 0:
							num = getRandom (20, 23);
							Battle.Enqueue (num);
							break;
						case 1:
							num = getRandom (30, 32);
							Battle.Enqueue (num);
							break;
						case 2:
							num = getRandom (40, 45);
							Battle.Enqueue (num);
							break;
						case 3:
							num = getRandom (50, 53);
							Battle.Enqueue (num);
							break;
						}
					}
				} 
				else {
					Battle.Enqueue (12);
				}
				num = (int)Battle.Dequeue ();
			}

			switch (num) 
			{
			case 0:
			case 3:
				time = Time_Move;
				break;
			case 1:
				time = Time_Nomal_Stop;
				break;
			case 2:
				time = Time_Nomal_Motion;
				break;
			default:
				time = 1.0f;
				break;
			}
			Debug.Log (num);
			yield return new WaitForSeconds (time);
		}
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}
//			int Dnum = 0;
//			AIDic.Add(Dnum, new AIstatus(Dnum,"Stop"));
//			Dnum = 1;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"NatureMove"));
//			Dnum = 2;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"StopMotion"));
//			Dnum = 3;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"MoveWay"));//사용자가 지정한 길을 따라 이동
//			
//			//전투상태
//			Dnum = 10;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"TagetSearch"));
//			Dnum = 11;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Move"));//추격
//			Dnum = 12;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"NomalAttack"));
//			
//			//기본 공격스킬
//			Dnum = 20;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"NomalSkill_1"));
//			Dnum = 21;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"NomalSkill_2"));
//			Dnum = 22;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"NomalSkill_3"));
//			Dnum = 23;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"NomalSkill_4"));
//			
//			//조건 부 스킬(상황에 맞는)
//			Dnum = 30;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"SpecialSkill_1"));
//			Dnum = 31;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"SpecialSkill_2"));
//			Dnum = 32;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"SpecialSkill_3"));
//			
//			//상태이상 치료
//			Dnum = 40;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Cure_All"));
//			Dnum = 41;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Cure_Freezing"));
//			Dnum = 42;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Cure_Burning"));
//			Dnum = 43;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Cure_Blooding"));
//			Dnum = 44;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Cure_Darkness"));
//			Dnum = 45;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Cure_ElecShocking"));
//			
//			//버프
//			Dnum = 50;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Buff_Heal"));
//			Dnum = 51;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Buff_Attack"));
//			Dnum = 52;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Buff_Ammor"));
//			Dnum = 53;
//			AIDic.Add(Dnum,new AIstatus(Dnum,"Buff_Shiled"));


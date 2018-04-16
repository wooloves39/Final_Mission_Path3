using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobGenerater : MonoBehaviour {

	public List<GameObject> Position;

	public List<GameObject> Prefab;
	public List<int> Prefab_Count;

	public bool Wave_Start = false;
	public List<int> GenTime;	
	public MemoryPool pool = new MemoryPool();

	int myTime = 0;



	void Start() {
		myTime = 0;
		for(int i = 0 ; i < Prefab.Count;++i)
		{
			pool.Create(Prefab[i], Prefab_Count[i]);
		}
		StartCoroutine("MobGen");
	}
	
	// Update is called once per frame

	IEnumerator MobGen()
	{
		int num = 0;
		while (true)
		{
			if (Wave_Start)
			{
				if (num < Prefab_Count.Count)
				{
					if (myTime >= GenTime[num])
					{

						for (int i = 0; i < Prefab_Count[num]; ++i)
						{
							if (i % 3 == 0)
							{
								pool.NewItem(Position[0].transform.position);
							}
							if (i % 3 == 1)
							{
								pool.NewItem(Position[1].transform.position);
							}
							if (i % 3 == 2)
							{
								pool.NewItem(Position[2].transform.position);
							}
						}
						num++;
					}
				}
				myTime++;
				if (myTime >= 1200)
					break;
				else
					yield return new WaitForSeconds(1);
			}
			yield return new WaitForSeconds(1);
		}
	}

	private void OnApplicationQuit()
	{
		pool.Dispose();
	}
}

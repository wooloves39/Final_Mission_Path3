using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePosition : MonoBehaviour {
	public Vector3[] StagePos;
	public int[] index;
	ArrayList[] NearPos = null;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < StagePos.Length; ++i)
		{
			index[i] = 0;
		}

		for (int i = 0; i < StagePos.Length; ++i)
		{
			for (int j = 0; j < StagePos.Length; ++j)
			{
				if (i == j)
					continue;
				if (Vector3.Distance(StagePos[i], StagePos[j]) <= 1.5f)
				{
					if (NearPos[i] == null)
						NearPos[i] = new ArrayList();
					index[i]++;
					NearPos[i].Add(StagePos[j]);
				}
				
			}
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

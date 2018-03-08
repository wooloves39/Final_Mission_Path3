using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePosition : MonoBehaviour {
	public Vector2 Horizental;
	public Vector2 Vertical;


	public GameObject positVec;

	public List<Vector3> StagePos;
	public List<int> index;
	public List<bool> PlayerHere;
	public List<bool> isEmpty;
	public List<Vector3> NearPos;
	// Use this for initialization
	void Start () {
		int temp = 0;
		for (int i = (int)Horizental.x; i < Horizental.y; i += 5)
		{
			for (int j = (int)Vertical.x; j < Vertical.y; j += 5)
			{
				StagePos.Add(new Vector3(i, 0, j));
				positVec.transform.position = StagePos[temp];
				Instantiate(positVec).transform.SetParent(this.transform);

				temp++;
			}
		}

		for (int i = 0; i < StagePos.Count; ++i)
		{
			index.Add(0);
		}
		//	for(int i = 0 ; i < StagePos.Count;++i)
		//	{
		//		for(int j = 0 ; j < StagePos.Count;++j)
		//		{
		//		}
		//	}
	}
}

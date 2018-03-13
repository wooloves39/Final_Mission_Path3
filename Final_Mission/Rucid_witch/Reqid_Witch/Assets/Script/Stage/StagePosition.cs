using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePosition : MonoBehaviour {
	public Vector2 Horizental;
	public Vector2 Vertical;

	public GameObject positVec;

	public List<Vector3> StagePos;
	private List<int> index;
	public int PlayerHere;
	private WayPoint[] Way;
	// Use this for initialization
	void Start () {
		int temp = 0;
		Way = new WayPoint[576];
		for (int i = (int)Horizental.x; i < Horizental.y; i += 5)
		{
			for (int j = (int)Vertical.x; j < Vertical.y; j += 5)
			{
				StagePos.Add(new Vector3(i, 0, j));
				positVec.transform.position = StagePos[temp];
				GameObject wp = (GameObject)(Instantiate(positVec));
				wp.transform.SetParent(this.transform);
				Way.SetValue(wp.GetComponent<WayPoint>(),temp);
					
				temp++;
			}
		}
		StartCoroutine("init");
	}
	void Update()
	{
		for (int i = 0; i < StagePos.Count; ++i)
		{
			if(index[i] == 1)
			{
				if (Way[i].PlayerIN)
				{
					PlayerHere = i;
					break;
				}
			}
		}
	}
	IEnumerator init()
	{
		int cnt = 0;
		while (true)
		{
			for (int i = 0; i < StagePos.Count; ++i)
			{
				if(cnt == 0)
					index.Add(0);
				if (Way[i].check == true)
				{
					index[i] = 1;
				}
			}
			cnt++;	
			if(cnt < 3)
				yield return new WaitForSeconds(10.0f);
			else
				break;
		}
	}
}

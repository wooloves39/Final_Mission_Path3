using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTower1 : MonoBehaviour {
	elecTowerCreate elecTower;
	LineRenderer line;
	public GameObject LinePrefab;
	public GameObject elecPrefab;
	public float elecRange = 5.0f;
	int num = 0;
	public List <Vector3>myarr;
	public List <float> distanse;
	float time = 0.0f;
	public int elecCount =2;
	//LineRenderer line;
	// Use this for initialization
	void Start () {
		elecTower = FindObjectOfType<elecTowerCreate> ();
		line = LinePrefab.GetComponent<LineRenderer> ();

		this.transform.parent = elecTower.transform;

		foreach(var i in elecTower.arr)
		{
			if(Vector3.Distance(this.transform.position+new Vector3(0,4,0),i)<elecRange&&this.transform.position+new Vector3(0,4,0) != i){
				
				line.SetPosition (0,i);
				myarr.Add (i);
				distanse.Add (Vector3.Distance(this.transform.position+new Vector3(0,4,0),i));
				num++;

				line.SetPosition (1,this.transform.position+new Vector3(0,4,0));
				Instantiate (LinePrefab,this.transform);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time>=0.2f)
		{
			for(int j=0;j<elecCount;++j){
				for(int i=0;i<num;++i){
					Instantiate (elecPrefab, ((this.transform.position + new Vector3 (0, 4, 0) - myarr [i]) / 10.0f * getRandom (3, 8) + myarr [i]), this.transform.rotation).transform.SetParent(this.transform);
				}
			}
			time = 0;
		}



	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}

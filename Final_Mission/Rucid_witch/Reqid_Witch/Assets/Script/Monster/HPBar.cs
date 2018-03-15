using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {
	private ObjectLife life;
	public GameObject[] Level;
	private int here;

	// Use this for initialization
	void Start () {
		life = GetComponentInParent<ObjectLife>();
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.LookAt(Camera);
		here = (int)(life.Hp / life.MaxHp * (Level.Length-1));
		Debug.Log(here);
		for (int i = 0; i < Level.Length; ++i)
		{
			if (i == here)
				Level[i].SetActive(true);
			else
				Level[i].SetActive(false);
		}
	}
}

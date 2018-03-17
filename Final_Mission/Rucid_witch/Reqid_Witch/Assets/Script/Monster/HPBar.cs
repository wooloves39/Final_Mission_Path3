using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {
	private ObjectLife life;
	public GameObject[] Level;
	public float here;

	// Use this for initialization
	void Start () {
		life = GetComponentInParent<ObjectLife>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(Camera.main.transform);
		here = (float)life.Hp / (float)life.MaxHp;
		here *= (Level.Length-1);
		for (int i = 0; i < Level.Length; ++i)
		{
			if (i == (int)here)
				Level[i].SetActive(true);
			else
				Level[i].SetActive(false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModInfo : MonoBehaviour {
	public Transform[] Objects;
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target.activeSelf)
		{
			for (int i = 0; i < Objects.Length; ++i)
			{
				Objects[i].Rotate(0, 1, 0);
			}
		}
	}
}

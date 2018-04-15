using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFollower : MonoBehaviour {
	public GameObject[] skill_logices;
	public SelectSkillUI selectSkillUI;
	private int checkSkill;
	// Use this for initialization
	void Start () {
		checkSkill = selectSkillUI.GetRotationSkill();
		skill_logices[checkSkill].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(checkSkill!= selectSkillUI.GetRotationSkill())
		{
			skill_logices[checkSkill].SetActive(false);
			checkSkill = selectSkillUI.GetRotationSkill();
			skill_logices[checkSkill].SetActive(true);
		}
	}
}

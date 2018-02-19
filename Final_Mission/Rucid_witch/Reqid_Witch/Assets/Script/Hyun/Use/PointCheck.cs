using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCheck : MonoBehaviour
{
	private bool Skill;
	private bool check;
	private AudioSource PointSound;
	// Use this for initialization
	private void Awake()
	{
		PointSound = GetComponent<AudioSource>();
	}
	void Start()
	{
		check = false;
		gameObject.SetActive(false);
		//PointSound = GetComponent<AudioSource>();
	}
	public void touchon()
	{
		StartCoroutine(Viberation.ViberationCoroutine(.1f, .2f, OVRInput.Controller.RTouch));
		PointSound.Play();
		check = true;
		this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
	}
	public void reset()
	{
		this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
		check = false;
		gameObject.SetActive(false);
	}
	public bool Getcheck()
	{
		return check;
	}
	public void turnon()
	{
		if (gameObject.activeSelf == false)
			gameObject.SetActive(true);
	}
	public void turnoff()
	{
		if (gameObject.activeSelf == true)
			gameObject.SetActive(false);
	}
	public void SetSkill(bool value)
	{
		Skill = value;
	}
	public bool GetSkill()
	{
		return Skill;
	}
}

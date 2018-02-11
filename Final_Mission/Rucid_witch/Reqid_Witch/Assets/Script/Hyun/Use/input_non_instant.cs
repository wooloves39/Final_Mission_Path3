﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_non_instant : MonoBehaviour
{
	private PointCheck MainPoint;
	public PointCheck[] Points;
	private PointCheck MyPoint;
	//현제 포인트 수
	private int count;
	//각 스킬 순서
	public int[] skill1;
	public int[] skill2;
	public int[] skill3;
	public int[] skill4;
	public int[] skill5;
	private int[] touchPoints;
	//완료 타이머
	private bool TimerOn=false;
	private float completeTimer;
	public GameObject Complete;
	public LineRenderer line;

	private Coroutine SkillCorutine;
	public AudioSource CompleteSound;

	// Use this for initialization
	void Start()
	{
			reset();
		gameObject.SetActive(false);
		
	}
	private void Awake()
	{
		MainPoint = Points[0];
		touchPoints = new int[skill5.Length];
		line.positionCount = 1;
		line.SetPosition(0, gameObject.transform.position);
	}
	public bool getTimerOn() { return TimerOn; }
	public int UpCount()
	{
		++count;
		return count;
	}
	public void reset()
	{
		if (MainPoint)
			MainPoint.turnon();
		count = -1;
		MyPoint = MainPoint;
		completeTimer = 0.0f;
		TimerOn = false;
		for (int i = 0; i < touchPoints.Length; ++i)
		{
			touchPoints[i] = 0;
		}
	}
	public void PointRestart()
	{
		for (int i = 0; i < Points.Length; ++i)
		{
			Points[i].reset();
		}
	}
	public void TouchPoint(PointCheck touchPoint)
	{
		MyPoint = touchPoint;
		line.positionCount = count + 1;
		line.SetPosition(count, MyPoint.transform.position);
		if (count >= 0)
		{
			for (int i = 0; i < Points.Length; ++i)
			{
				if (MyPoint == Points[i])
				{
					if (touchPoints != null)
					{
						touchPoints[count] = i;
					}
					break;
				}
			}
		}
	}
	private void SkillTime()
	{
		if (TimerOn == true)
		{
			completeTimer += Time.deltaTime;
			if (completeTimer > 2.0f)
			{
				PointRestart();
				TimerOn = false;
				Complete.SetActive(false);
				reset();
				gameObject.SetActive(false);
				if (SkillCorutine != null)
				{
					StopCoroutine(SkillCorutine);
					SkillCorutine = null;
				}

			}
		}
	}
	private void PointReset()
	{
		for (int i = 0; i < Points.Length; ++i)
		{
			Points[i].turnoff();
		}
	}
	private void lineReset()
	{
		line.positionCount = 1;
	}
	private void PointCheck(int[] skill)
	{

		if (skill.Length >= count + 1)
		{
			for (int i = 0; i < count; ++i)
			{
				if (skill[i] != touchPoints[i])
					return;
			}
			if (Points[skill[count]] == MyPoint)
			{
				if (skill.Length == count + 1)
				{
					for (int i = 0; i <= count; ++i)
					{
						Points[skill[i]].turnon();
					}
					PlayingSound();
				}
				else
				{
					for (int i = 0; i <= count + 1; ++i)
					{
						Points[skill[i]].turnon();
					}
				}
			}
		}
	}
	//한번만 소리나게 변경해보기.
	private void PlayingSound()
	{
		if (!CompleteSound.isPlaying)
		{
			CompleteSound.Play();
		}
	}
	private void PointChecks()
	{
		if (count >= 0)
		{
			PointReset();
			PointCheck(skill1);
			PointCheck(skill2);
			PointCheck(skill3);
			PointCheck(skill4);
			PointCheck(skill5);

		}
	}
	private bool SkillCheck(int[] skill)
	{
		if (skill.Length == count + 1)
		{
			for (int i = 0; i <= count; ++i)
			{
				if (skill[i] != touchPoints[i])
					return false;
			}
			SkillCorutine = StartCoroutine(SkillComplete());
			return true;
		}
		return false;

	}
	public void SkillOn()
	{
		lineReset();
		if (SkillCheck(skill1))
		{
			Debug.Log(1);
			Debug.Log("마법 발동!!"); TimerOn = true;
			Complete.SetActive(true);
			return;
		}
		else if (SkillCheck(skill2))
		{
			Debug.Log(2);
			Debug.Log("마법 발동!!");
			TimerOn = true;
			Complete.SetActive(true);
			return;
		}
		else if (SkillCheck(skill3))
		{
			Debug.Log(3);
			Debug.Log("마법 발동!!");
			TimerOn = true;
			Complete.SetActive(true);
			return;
		}
		else if (SkillCheck(skill4))
		{
			Debug.Log(4);
			Debug.Log("마법 발동!!");
			TimerOn = true;
			Complete.SetActive(true);
			return;
		}
		else if (SkillCheck(skill5))
		{
			Debug.Log(5);
			Debug.Log("마법 발동!!");
			TimerOn = true;
			Complete.SetActive(true);
			return;
		}

		PointRestart();
		TimerOn = false;
		reset();
		gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update()
	{
		//SkillTime();
		PointChecks();
	}
	private IEnumerator SkillComplete()
	{
		yield return new WaitUntil(() => TimerOn);
		//yield return new WaitWhile(() => TimerOn);
			while (TimerOn)
			{
				SkillTime();
				yield return null;
			}
		
	}
}

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
	public float[] MaxChargingTimes;
	private int[] touchPoints;
	//완료 타이머
	private bool TimerOn = false;
	private float completeTimer;
	private float skillSoundTimer;

	private int currentSkill=1;
	public GameObject Complete;
	public LineRenderer line;
	private Coroutine SkillCorutine;
	private AudioSource CompleteSound;
	private Viberation PlayerViberation;

	private Transform Player;
	private Vector3 initPos;
	private List<Vector3> PointsVec = new List<Vector3>();
	// Use this for initialization
	void Start()
	{
		CompleteSound = GetComponent<AudioSource>();
		CompleteSound.volume = Singletone.Instance.Sound;
		reset();
		gameObject.SetActive(false);
	}
	private void Awake()
	{
		Player = transform.parent.parent.GetComponent<Transform>();
		PlayerViberation = gameObject.transform.parent.parent.GetComponent<Viberation>();
		MainPoint = Points[0];
		touchPoints = new int[skill5.Length];
		line.positionCount = 1;
		line.SetPosition(0, gameObject.transform.position);
		PointsVec.Add(gameObject.transform.position);
	}
	private void OnEnable()
	{
		initPos = Player.position;
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
		PointsVec.Clear();
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
		PointsVec.Add(MyPoint.transform.position);
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
		PointsVec.Clear();
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
	private void PlayingSound()
	{
		skillSoundTimer += Time.deltaTime;
		if (!CompleteSound.isPlaying&&skillSoundTimer>0.0f)
		{
			skillSoundTimer = -4.0f;
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
			currentSkill = 1;
			Debug.Log("마법1");
			TimerOn = true;
			Complete.SetActive(true);
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.LTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.RTouch));
			return;
		}
		else if (SkillCheck(skill2))
		{
			currentSkill = 2;
			Debug.Log("마법2");
			TimerOn = true;
			Complete.SetActive(true);
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.LTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.RTouch));
			return;
		}
		else if (SkillCheck(skill3))
		{
			currentSkill = 3;
			Debug.Log("마법3");
			TimerOn = true;
			Complete.SetActive(true);
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.LTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.RTouch));
			return;
		}
		else if (SkillCheck(skill4))
		{
			currentSkill = 4;
			Debug.Log("마법4");
			TimerOn = true;
			Complete.SetActive(true);
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.LTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.RTouch));
			return;
		}
		else if (SkillCheck(skill5))
		{
			currentSkill = 5;
			Debug.Log("마법5");
			TimerOn = true;
			Complete.SetActive(true);
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.LTouch));
			PlayerViberation.StartCoroutine(Viberation.ViberationCoroutine(.3f, .3f, OVRInput.Controller.RTouch));
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
		for(int i = 0; i < PointsVec.Count; ++i)
		{
			line.SetPosition(i, PointsVec[i] + (Player.position - initPos));
		}
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
	public int getCurrentSkill() { return currentSkill; }
	public void resetSkill()
	{
		currentSkill = 1;

	}
	public float GetSkillChargingTime() { return MaxChargingTimes[currentSkill]; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzuraSkill : MonoBehaviour
{
	private int skill;
	private GameObject target;
	private float handDis;
	float deltaTime;
	public GameObject Blast;
	public GameObject[] WitchsHones;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
	}

	// Update is called once per frame
	void Update()
	{

	}
	public void shoot(int skillIndex, GameObject targets, float handDistance)
	{
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
		switch (skill)
		{
			case 1:
				WitchsHone();
				break;
			case 2:
				SoulExplosion(target.transform.position);
				break;
			case 3:
				witchAging(2.0f, 10f);
				break;
			case 4:
				callofGad(10f, 3f, 5f);
				break;
			case 5:
				LastBlast();
				break;
		}
		target = null;
	}
	private void WitchsHone()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		if (target != null)
		{
			Vector3 TargettingDir = Vector3.Normalize((target.transform.position) - transform.position);//;
			r.velocity = TargettingDir * 15f * handDis;
			GetComponent<Arrow>().Shooting(true);
		}
	}
	void SoulExplosion(Vector3 target)//12개의 스킬 날리기
	{
		StartCoroutine(SoulExplosionCor(target));
	}
	IEnumerator SoulExplosionCor(Vector3 target)
	{
		Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
		float speed = Random.Range(10, 15);
		float Timer = 0.0f;
		float MaxTime = Vector3.Distance(transform.position, target) / 20f;
		while (true)
		{
			Timer += deltaTime;
			if (Vector3.Distance(transform.position, target) < 0.5f) break;
			transform.LookAt(target);
			Vector3 lookPos = transform.forward;
			if (Timer < MaxTime)
			{
				lookPos += dir / 2.0f;
				transform.Translate(lookPos * deltaTime * speed);
			}
			else
			{
				transform.Translate(target.normalized * deltaTime * speed);
			}
			yield return null;
		}
	}
	void witchAging(float speed, float deltime)//12개
	{
		for (int i = 1; i < childHone.Length; ++i)
		{
			childHone[i].Rotate(0, i * 15, 0);
			StartCoroutine(witchAgingCour(i, speed, deltime));
		}
	}
	IEnumerator witchAgingCour(int indexNum, float speed, float deltime)
	{
		float timer = 0.0f;
		while (true)
		{
			if (timer > deltime) break;
			timer += deltaTime;
			childHone[indexNum].transform.Translate(childHone[indexNum].transform.forward * speed * Time.deltaTime);
			yield return null;
		}
	}
	void callofGad(float speed, float scale, float time)
	{
		StartCoroutine(callofGadCor(speed, scale, time));
	}
	IEnumerator callofGadCor(float speed, float scale, float time)
	{
		float timer = 0.0f;
		float cur_Scale = 1.0f;
		while (true)
		{
			timer += deltaTime;
			cur_Scale = scale * (timer / time);
			Vector3 scaleVector = Vector3.one;
			if (cur_Scale < 1.0f) cur_Scale = 1.0f;
			transform.localScale = scaleVector * cur_Scale;
			transform.Translate(transform.forward * deltaTime * speed);
			if (timer > time) break;
			yield return null;
		}
	}
	private void LastBlast()
	{
		StartCoroutine(LastBlastCor());
	}
	IEnumerator LastBlastCor()
	{
		float timer = 0.0f;
		timer += deltaTime;
		transform.Rotate(0, 10 * timer, 0);
		if (timer >= 2.0f)
		{
			timer = 0;
			transform.rotation = Quaternion.identity;
			gameObject.SetActive(false);
			//내위치 변경
		}
		yield return null;
	}
}

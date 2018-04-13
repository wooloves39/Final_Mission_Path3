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
	public GameObject witchsHone;
	public GameObject SoulExp;
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
				callofGad(target.transform.position,10f, 3f, 5f);
				break;
			case 5:
				LastBlast();
				break;
		}
		GetComponent<Arrow>().Shooting(true);
		target = null;
	}
	private void WitchsHone()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 TargettingDir = Vector3.Normalize((target.transform.position) - transform.position);//;
		r.velocity = TargettingDir * 15f * handDis;
		
	}
	void SoulExplosion(Vector3 target)//12개의 스킬 날리기
	{
		GameObject[] souls = new GameObject[12];
		for (int i = 0; i < souls.Length; ++i)
		{
			souls[i] = Instantiate(SoulExp, transform);
			StartCoroutine(SoulExplosionCor(souls[i], target));
		}
	}
	IEnumerator SoulExplosionCor(GameObject soul, Vector3 target)
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
		GameObject[] witchsHones = new GameObject[8];
		for (int i = 0; i < witchsHones.Length; ++i)
		{
			witchsHones[i] = Instantiate(witchsHone, transform);
			witchsHones[i].transform.Rotate(0, i * 15, 0);
			StartCoroutine(witchAgingCour(witchsHones[i], speed, deltime));
		}
	}
	IEnumerator witchAgingCour(GameObject hone, float speed, float deltime)
	{
		float timer = 0.0f;
		while (true)
		{
			if (timer > deltime) break;
			timer += deltaTime;
			hone.transform.Translate(hone.transform.forward * speed * Time.deltaTime);
			yield return null;
		}
	}
	void callofGad(Vector3 targetPos,float speed, float scale, float time)
	{
		StartCoroutine(callofGadCor(targetPos, speed, scale, time));
	}
	IEnumerator callofGadCor(Vector3 targetPos, float speed, float scale, float time)
	{
		float timer = 0.0f;
		float cur_Scale = 1.0f;
		while (true)
		{
			timer += deltaTime;
			cur_Scale = scale * (timer / time);
			Vector3 scaleVector = Vector3.one;
			if (cur_Scale < 1.0f) cur_Scale = 1.0f;
			SoulExp.transform.localScale = scaleVector * cur_Scale;
			SoulExp.transform.Translate(Vector3.Normalize(targetPos-transform.position) * deltaTime * speed);
			if (timer > time) break;
			yield return null;
		}
	}
	private void LastBlast()
	{
	//	Blast.SetActive(true);
		StartCoroutine(LastBlastCor());
	}
	IEnumerator LastBlastCor()
	{
		float timer = 0.0f;
		timer += deltaTime;
		Blast.transform.Rotate(0, 10 * timer, 0);
		if (timer >= 2.0f)
		{
			timer = 0;
			Blast.transform.rotation = Quaternion.identity;
			Blast.gameObject.SetActive(false);
			//내위치 변경
		}
		yield return null;
	}
}

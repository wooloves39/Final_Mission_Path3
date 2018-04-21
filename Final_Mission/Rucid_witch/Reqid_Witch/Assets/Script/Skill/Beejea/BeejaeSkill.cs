using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeejaeSkill : MonoBehaviour
{
	public GameObject[] magic;
	public bool buff = false;

	private bool WorkON = false;
	private int skill;
	private GameObject target;
	private float handDis;
	float deltaTime;

	private bool Shoot = false;
	private bool del_timer = false;

	private Collider collider;
	private PlayerState Player;

	private Teleport handle;
	public bool handle2 = false;

	private void Awake()
	{
		handle = FindObjectOfType<Teleport>();
		handle2 = FindObjectOfType<SkillAttack1>();
		Player = FindObjectOfType<PlayerState>();
		deltaTime = Time.deltaTime;
		collider = GetComponent<Collider>();
	}
	private void Update()
	{
		if(handle.Beejae_Marker[0].gameObject.activeInHierarchy == false && handle.Beejae_Marker[1].gameObject.activeInHierarchy == false && handle2 == true)
		{
			handle2 = false;
			shoot(handle.typecheck.Skills[0].getCurrentSkill(), handle.PlayerTarget.getMytarget(), 0.0f);
		}
	}

	public void shoot(int skillIndex, GameObject targets, float handDistance)
	{
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
		switch (skill)
		{
			case 0:
				StartCoroutine("SkyThunder");
				break;
			case 1:
				StartCoroutine("SkyThunder");
				break;
			case 2:
				StartCoroutine("Buff");
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
		}
		if (skill > 1)
			UseOtherObject();
		target = null;
	}
	IEnumerator SkyThunder()
	{
		magic[0].transform.position = target.transform.position;
		magic[0].SetActive(true);
		yield return new WaitForSeconds(0.45f);
		if (Player.LightningBolt)
		{
			handle.PlayerTarget.getMytarget().SendMessage("Shock");
		}
		handle.PlayerTarget.getMytarget().GetComponentInParent<ObjectLife>().SendMessage("SendDMG", 30.0f);
		yield return new WaitForSeconds(0.30f);
		magic[0].SetActive(false);
	}

	IEnumerator Buff()
	{
		Player.LightningBolt = true;
		yield return new WaitForSeconds(60.0f);
		Player.LightningBolt = false;
	}

	private void UseOtherObject()
	{
		collider.enabled = false;
	}
}

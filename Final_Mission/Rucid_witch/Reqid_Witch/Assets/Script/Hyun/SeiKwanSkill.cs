using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeiKwanSkill : MonoBehaviour
{

	// Use this for initialization
	private int skill;
	private GameObject target;
	private float handDis;
	float deltaTime;
	public GameObject Gate;
	public GameObject Guard;
	public GameObject[] sky_Arraws;
	public GameObject arrow_trab_particle;

	private bool Shoot = false;
	private bool del_timer = false;

	private Collider collider;
	public GameObject SeiKwanArrow;


	private Vector3 curScale;
	private void Awake()
	{
		deltaTime = Time.deltaTime;
		collider = GetComponent<Collider>();
	}
	public void shoot(int skillIndex, GameObject targets, float handDistance,float del_time=2.0f)
	{
		transform.localScale = transform.localScale * 3;
		target = targets;
		skill = skillIndex;
		handDis = handDistance;
		switch (skill)
		{
			case 1:
				BraveArrow();
				break;
			case 2:
				ArrowTrab();
				break;
			case 3:
				SkyArrow();
				break;
			case 4:
				SavenGuard();
				break;
			case 5:
				HavensGate();
				break;
		}
		//if (skill > 1) UseOtherObject();
		Shoot = true;
		StartCoroutine(Shooting(del_time));
		target = null;
	}
	private void BraveArrow()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			r.velocity = Arrowforward * 15f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			r.velocity = TargettingDir * 15f * handDis;
		}
	}
	private void ArrowTrab()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			r.velocity = Arrowforward * 15f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			r.velocity = TargettingDir * 15f * handDis;
		}

	}
	IEnumerator ArrowTrabCor(float timer)
	{
		yield return new WaitForSeconds(timer);
		arrow_trab_particle.SetActive(true);

	}
	private void SkyArrow()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		r.velocity = Vector3.up * 15f * handDis;
	}
	IEnumerator SkyArrowCor(GameObject skyArrow, Vector3 target, float timer)
	{
		Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
		float speed = Random.Range(5, 10);
		yield return new WaitForSeconds(timer);
		skyArrow.SetActive(true);
		transform.position= transform.position + dir;
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 TargettingDir = Vector3.Normalize(target - transform.position);
		r.velocity = TargettingDir * 15f * handDis;
	}
	private void SavenGuard() {
		Guard.SetActive(true);
	}
	IEnumerator SavenGuardCor(float timer,float handDis)
	{
		float ScaleTimer = 0.0f;
		Vector3 scale=new Vector3(1,1,1);
		while (true)
		{ scale *= handDis * (ScaleTimer / timer);
			ScaleTimer += deltaTime;
			Guard.transform.localScale = Guard.transform.localScale + scale;
			if (timer <= ScaleTimer) break;
			yield return null;
		}
		Guard.transform.localScale = new Vector3(1, 1, 1);
		Guard.SetActive(false);

	}
	private void HavensGate() {
		MeshRenderer mesh = GetComponent<MeshRenderer>();
		mesh.enabled = false;
		Rigidbody r = GetComponent<Rigidbody>();
		Vector3 Arrowforward = transform.forward;
		Vector3 TargettingDir = Vector3.Normalize(target.transform.position - transform.position);
		if (Vector3.Dot(TargettingDir, Arrowforward) < 0.8f || TargettingDir == Vector3.zero)
		{
			r.velocity = Arrowforward * 15f * handDis;
		}
		else
		{
			TargettingDir += Arrowforward;
			r.velocity = TargettingDir * 15f * handDis;
		}
	}
	IEnumerator HavensGateCor(int timer)
	{
		yield return new WaitForSeconds(timer);
		Gate.SetActive(false);
	}
	IEnumerator Shooting(float delTime = 2.0f)
	{
		yield return new WaitForSeconds(delTime);
		del_timer = true;
		Shoot = false;
	}
	public bool IsDelete() { return del_timer; }
	public bool IsShoot() { return Shoot; }
	public void resetDelete()
	{
		SeiKwanArrow.SetActive(true);
		collider.enabled = true;
		Gate.transform.position = transform.position;
		Gate.transform.localScale = transform.localScale;
		Gate.transform.rotation = transform.rotation;
		Gate.SetActive(false);
		Guard.transform.position = transform.position;
		Guard.transform.localScale = transform.localScale;
		Guard.transform.rotation = transform.rotation;
		Guard.SetActive(false);
		arrow_trab_particle.transform.position = transform.position;
		arrow_trab_particle.transform.localScale = transform.localScale;
		arrow_trab_particle.transform.rotation = transform.rotation;
		arrow_trab_particle.SetActive(false);
		for (int i = 0; i < sky_Arraws.Length; ++i)
		{
			sky_Arraws[i].transform.position = transform.position;
			sky_Arraws[i].transform.localScale = transform.localScale;
			sky_Arraws[i].transform.rotation = transform.rotation;
			sky_Arraws[i].SetActive(false);
		}
		del_timer = false;
	}
	private void UseOtherObject()
	{
		SeiKwanArrow.SetActive(false);
		collider.enabled = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (skill == 5)
		{
			Gate.SetActive(true);
		}
	}
}

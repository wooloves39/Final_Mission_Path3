using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	private bool shot = false;
	private bool seikwan_timer = false;
	private bool touch = false;
	private float timer;
	private Vector3 curScale;
	public GameObject particle;
	public GameObject arrow;
	private ParticleSystem particleSystem;
	// Use this for initialization
	void Awake()
	{
		particleSystem = GetComponentInChildren<ParticleSystem>();
		timer = new int();
		timer = 0.0f;
		curScale = gameObject.transform.localScale;
	}

	// Update is called once per frame
	void Update()
	{
		if (shot == true)
		{
			timer += Time.deltaTime;
			if (timer >= 2.0f&&!touch)
				seikwan_timer = true;
			if (touch)
			{
				if (!particleSystem.isPlaying)
				{
					touch = false;
				}
			}
		}
	}
	public void Shooting(bool val)
	{
		shot = val;
	}
	public bool IsShooting() { return shot; }
	public bool IsDelete()
	{
		return seikwan_timer;
	}
	public void resetArrow()
	{
		shot = false;
		seikwan_timer = false;
		timer = 0.0f;
		gameObject.transform.localScale = curScale;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("monster"))
		{
			touch = true;
			arrow.SetActive(false);
			particle.SetActive(true);
		}
	}
}

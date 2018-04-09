﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSimulatir : MonoBehaviour {
	//private Transform sunrise;
	//private Vector3 sunset;
	//public float journeyTime = 1.0F;
	//private float startTime;
	//void Start()
	//{
	//	sunrise = transform;
	//	Vector3 pos = transform.position;
	//	pos.z += 100;
	//	sunset = pos;
	//	   startTime = Time.time;
	//}
	//void Update()
	//{
	//	Vector3 direct= new Vector3(0, 1, 0);
		
	//	Vector3 center = (sunrise.position + sunset) * 0.5F;
	//	center -= direct.normalized;
	//	Vector3 riseRelCenter = sunrise.position - center;
	//	Vector3 setRelCenter = sunset - center;
	//	float fracComplete = (Time.time - startTime) / journeyTime;
	//	transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
	//	transform.position += center;
	//}
	


	private Transform bullet;   // 포물체
	private float tx;
	private float ty;
	private float tz;
	private float v;
	public float g = 9.8f;
	private float elapsed_time;
	public float max_height;
	private float t;
	private Vector3 start_pos;
	private Vector3 end_pos;
	private float dat;  //도착점 도달 시간 
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{ Vector3 pos = transform.position;
			pos.z += 10;
			Shoot(transform, transform.position, pos, g, max_height);
		}
	}
	public void Shoot(Transform bullet, Vector3 startPos, Vector3 endPos, float g, float max_height)
	{
		transform.Rotate(90, 90, 0,Space.Self);
		start_pos = startPos;
		end_pos = endPos;
		this.g = g;
		this.max_height = max_height;
		this.bullet = bullet;
		this.bullet.position = start_pos;
		var dh = endPos.y - startPos.y;
		var mh = max_height - startPos.y;
		ty = Mathf.Sqrt(2 * this.g * mh);
		float a = this.g;
		float b = -2 * ty;
		float c = 2 * dh;
		dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
		tx = -(startPos.x - endPos.x) / dat;

		tz = -(startPos.z - endPos.z) / dat;
		this.elapsed_time = 0;
		StartCoroutine(this.ShootImpl());
	}
	IEnumerator ShootImpl()
	{
		while (true)
		{
			this.elapsed_time += Time.deltaTime;
			var tx = start_pos.x + this.tx * elapsed_time;
			var ty = start_pos.y + this.ty * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
			var tz = start_pos.z + this.tz * elapsed_time;
			var tpos = new Vector3(tx, ty, tz);
			//bullet.transform.LookAt(tpos);
			bullet.transform.position = tpos;
			if (this.elapsed_time >= this.dat)
				break;
			yield return null;

		}

	}
}

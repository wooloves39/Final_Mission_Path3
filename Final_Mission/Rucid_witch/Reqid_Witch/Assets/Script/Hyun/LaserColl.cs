using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColl : MonoBehaviour {
	public input_mouse Rtouch;
	private void OnTriggerEnter(Collider other)
	{
		PointCheck col;
		if (other.gameObject.GetComponent<PointCheck>())
		{
			col = other.gameObject.GetComponent<PointCheck>();
			if (!col.Getcheck())
			{
				col.touchon();
				Rtouch.Upcount(col);
			}
		}
	}
}

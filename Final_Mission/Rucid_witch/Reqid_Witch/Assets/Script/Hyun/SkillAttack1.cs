using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillAttack1 : MonoBehaviour
{
	private Image PointImage;
	private Color cur_Color;//평소
	private Color touch_Color;//점끼리 마주쳤을때
	public static bool isTouch = false;
	// Use this for initialization
	private void Awake()
	{
		PointImage =gameObject.transform.GetComponentInChildren<Image>();
		cur_Color = PointImage.color;
		touch_Color = new Color(0, 0, 0);
	}
	private void OnEnable()
	{
		isTouch = false;
	}
	private void Update()
	{
		if (isTouch)
		{
			PointImage.color = touch_Color;
		}
		else
		{
			PointImage.color = cur_Color;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Point"))
		{
			isTouch = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Point"))
		{
			isTouch = false;
		}
	}
}

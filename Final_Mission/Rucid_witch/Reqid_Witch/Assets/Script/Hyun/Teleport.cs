using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public GameObject TeleportMarker;
	public float RayLength = 50f;
	private Coroutine pointCorutine;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.LTriggerOn() && InputManager_JHW.RTriggerOn())
		{
			pointCorutine = StartCoroutine(PointControll());
		}
		else
		{
			if (pointCorutine != null)
				StopCoroutine(pointCorutine);
			TeleportMarker.SetActive(false);
		}
	}
	private IEnumerator PointControll()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, RayLength))
		{
			if (hit.collider.CompareTag("Ground"))
			{
				if (!TeleportMarker.activeSelf)
				{
					TeleportMarker.SetActive(true);
				}
				Vector3 point = hit.point;
				point.y += 0.2f;
				TeleportMarker.transform.position = point;
				yield return new WaitForSeconds(0.5f);
			}
			
		}
	}
}

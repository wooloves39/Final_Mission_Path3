using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viberation : MonoBehaviour {
	public  static IEnumerator ViberationCoroutine(float time,float power, OVRInput.Controller controller)
	{
		float Vi_Time = 0.0f;
		while (Vi_Time >= time)
		{
			Vi_Time += Time.deltaTime;
			OVRInput.SetControllerVibration(.2f, power, controller);
			yield return null;
		}
		OVRInput.SetControllerVibration(.2f, 0, controller);
		yield return null;
	}
	public static IEnumerator ViberationCoroutine(float time, float startPower,float EndPower, OVRInput.Controller controller)
	{
		float Vi_Time = 0.0f;
		float power = startPower;
		while (Vi_Time >= time)
		{
			Vi_Time += Time.deltaTime;
			if (power > EndPower) power -= 0.1f;
			else if (power < EndPower) power += 0.1f;
			OVRInput.SetControllerVibration(.2f, power, controller);
			yield return null;
		}
		OVRInput.SetControllerVibration(.2f, 0, controller);
		yield return null;
	}
}

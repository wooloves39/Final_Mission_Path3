using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour {

	public int speed = 10;
	public int timer = 100;

	bool check = false;
	int cnt = 0;

	float x = 0.0f;
	float y = 0.0f;
	float z = 0.0f;

	// Update is called once per frame
	void Update () {
		if (!check) 
		{
			x = getRandom (0, 180);
			y = getRandom (0, 180);
			z = getRandom (0, 180);
			check = true;
			Debug.Log ("Reset");
		}
		if (check) 
		{
			this.transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime * speed);
			cnt++;
			if (cnt > timer) {
				cnt = 0;
				check = false;
			}
		}
		Debug.Log (cnt);
	}
	int getRandom(int x,int y)
	{
		return Random.Range (x, y);
	}
}

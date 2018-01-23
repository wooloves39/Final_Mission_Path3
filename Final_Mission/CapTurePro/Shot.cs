using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
	CapturePanorama.CapturePanorama d;
	// Use this for initialization
	void Start () {
		d = new CapturePanorama.CapturePanorama();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			for (int i = 0; i < 9; ++i)
				d.CaptureScreenshotAsync("i.png");
		}
	}
}

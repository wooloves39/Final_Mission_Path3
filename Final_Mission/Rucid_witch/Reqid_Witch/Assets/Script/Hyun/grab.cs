using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour {

    // Update is called once per frame
    void Update() {
		if (Input.anyKey)
		{
			if (Input.GetButtonDown("AButton")) InputManager_JHW.AButton() ;
			if (Input.GetButtonDown("BButton")) Debug.Log("bButton");
			if (Input.GetButtonDown("XButton")) Debug.Log("xButton");
			if (Input.GetButtonDown("YButton")) Debug.Log("yButton");
			if (Input.GetAxis("LTrigger")==1) Debug.Log("LTrigger");
			if (Input.GetAxis("RTrigger")==1) Debug.Log("RTrigger");
			if (Input.GetButtonDown("LTouchButton")) Debug.Log("LTouchButton");
			if (Input.GetButtonDown("RTouchButton")) Debug.Log("RTouchButton");
			if (Input.GetButtonDown("Menu")) Debug.Log("Menu");
			if (Input.GetAxis("LTouchHandle")>0.5f) Debug.Log("LTouchHandle");
			if (Input.GetAxis("RTouchHandle")>0.5f) Debug.Log("RTouchHandle");
		}
       
    }
}

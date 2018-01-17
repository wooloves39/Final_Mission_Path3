using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Load;
	public GameObject Option;
	public bool VR = true;
	int cnt;
	int index = 0;
	float vertical = 0.0f;
	float horizental = 0.0f;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable ()
	{
		cnt = 0;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		while(this.gameObject.activeInHierarchy == true)
		{

			vertical = 0.0f;
			horizental = 0.0f;
			vertical += Input.GetAxis("LThumbstickY");
			horizental += Input.GetAxis("RThumbstickX");
			//KeyBoard

			if (vertical < 0)
				if (index != 3)
					index++;

			if (vertical > 0)
				if (index != 0)
				index--;
			
			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);
			
			if ((Input.GetAxis("LTrigger") == 1)|| (Input.GetAxis("RTrigger") == 1))
			{
				if (cnt > 0)
				{
					this.gameObject.SetActive(false);
					if (index == 0)
						SceneManager.LoadScene("Ready Scene");
					if (index == 1)
						Load.SetActive(true);
					if (index == 2)
					{
					}//멀티플레이
					if (index == 3)
						Option.SetActive(true);
					yield return new WaitForSeconds(0.250f);
				}
				cnt++;
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Main;
	int index = 0;
	int cnt;
	float vertical = 0.0f;
	float horizental = 0.0f;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable ()
	{
		cnt = 0;
		index = 0;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		while(this.gameObject.activeInHierarchy == true)
		{
			//KeyBoard	
			vertical = 0.0f;
			horizental = 0.0f;
			vertical += Input.GetAxis("LThumbstickY");
			horizental += Input.GetAxis("RThumbstickX");
			if(horizental > 0)
				if (index != 2&&index != 3)
					index++;

			if (horizental < 0)
				if (index != 0&&index != 3)
				index--;


			if (vertical < 0)
				index = 3;

			if (vertical > 0)
				index = 2;

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);
			//KeyBoard - Enter
			if ((Input.GetAxis("LTrigger") == 1) || (Input.GetAxis("RTrigger") == 1))
			{

				Debug.Log("touch");
				if (cnt>0)
				{
					this.gameObject.SetActive(false);
					if (index == 0)
						SceneManager.LoadScene("Ready Scene");
					if (index == 1)
						SceneManager.LoadScene("Ready Scene");
					if (index == 2)
						SceneManager.LoadScene("Ready Scene");
					if (index == 3)
						Main.SetActive(true);

					yield return new WaitForSeconds(0.250f);
				}
				cnt++;
			}
			yield return new WaitForSeconds(0.125f);
		}
	}
}
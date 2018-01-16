using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Load;
	public GameObject Option;
	int index = 0;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable () {
			StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		while(this.gameObject.activeInHierarchy == true)
		{
			//KeyBoard
			if (Input.GetKey ("s"))
			if (index != 3)
				index++;

			if (Input.GetKey ("w"))
			if (index != 0)
				index--;
			
			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);
			yield return new WaitForSeconds (0.1f);

			//KeyBoard - Enter
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
				this.gameObject.SetActive (false);
				if(index == 0)
					SceneManager.LoadScene("Ready Scene");
				if(index == 1)
					Load.SetActive(true);
				if (index == 2) {
				}//멀티플레이
				if(index == 3)
					Option.SetActive(true);
				yield return new WaitForSeconds (0.1f);
			}
		}
	}
}
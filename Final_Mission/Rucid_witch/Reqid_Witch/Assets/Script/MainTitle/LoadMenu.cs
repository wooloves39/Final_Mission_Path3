using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {
	public GameObject[] Select;
	public GameObject Main;
	int index = 0;
	// Use this for initialization

	// Update is called once per frame
	void OnEnable () {
		index = 0;
		StartCoroutine ("KeyPad");
	}
	IEnumerator KeyPad(){
		while(this.gameObject.activeInHierarchy == true)
		{
			//KeyBoard
			if (Input.GetKey ("d"))
			if (index != 2&&index != 3)
				index++;

			if (Input.GetKey ("a"))
			if (index != 0&&index != 3)
				index--;

			if (Input.GetKey ("s"))
				index = 3;

			if (Input.GetKey ("w"))
				index = 2;
			yield return new WaitForSeconds (0.1f);

			for (int i = 0; i < Select.Length; ++i) {
				Select [i].SetActive (false);
			}
			Select [index].SetActive (true);
			//KeyBoard - Enter
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
				this.gameObject.SetActive (false);
				if(index == 0)
					SceneManager.LoadScene("Ready Scene");
				if(index == 1)
					SceneManager.LoadScene("Ready Scene");
				if(index == 2)
					SceneManager.LoadScene("Ready Scene");
				if(index == 3)
					Main.SetActive(true);
				yield return new WaitForSeconds (0.1f);
			}
		}
	}
}
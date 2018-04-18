using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newConfirmMenu : MonoBehaviour {

	private SceneChange sceneChange;
	int index = 1;
	public GameObject[] Select;
	public GameObject main;
	private void Awake()
	{
		sceneChange = FindObjectOfType<SceneChange>();
	}
	void OnEnable()
	{
		index = 1;
		StartCoroutine(KeyPad());
	}
	private void Update()
	{
		if (InputManager_JHW.AButtonDown())
		{
			if (index == 1)
				sceneChange.sceneChange("StartNew");
			if (index == 0)
			{
				main.GetComponent<MainMenu>().confirm = false;
				this.gameObject.SetActive(false);
			}
		}
	}
	IEnumerator KeyPad()
	{

		Vector3 Stick;
		while (this.gameObject.activeInHierarchy == true)
		{
			Stick = InputManager_JHW.MainJoystick();

			if (Stick.x < 0)
				index = 0;

			if (Stick.x > 0)
				index = 1;

			for (int i = 0; i < Select.Length; ++i)
			{
				Select[i].SetActive(false);
			}
			Select[index].SetActive(true);
			yield return new WaitForSeconds(0.125f);
		}
	}
}

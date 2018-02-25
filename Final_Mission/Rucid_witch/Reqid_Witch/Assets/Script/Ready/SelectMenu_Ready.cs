using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu_Ready : MonoBehaviour {

	public GameObject[] ui_arr;
	public Vector2[] posit_arr;
	public int index = 0;
	public Vector2 myposit = new Vector2(0,1);
	public bool confirm = false;
	public bool move = true;
	public int SelectMenu = -1;
	float timer = 0.0f;


	void Start(){
		StartCoroutine("KeyPad");
	}

	IEnumerator KeyPad()
	{
		
		while (true)
		{
			if (!confirm)
			{
				Vector3 Stick;
				if (move)
				{
					if (timer < 1.0f)
						timer += Time.deltaTime * 25;
					Stick = InputManager_JHW.MainJoystick();

					if (Stick.x > 0)
					{
						if (myposit.x < 2)
							myposit.x++;
					}

					if (Stick.x < 0)
					{
						if (myposit.x > -1)
							myposit.x--;
					}
					if (Stick.z > 0)
					{
						myposit.y = 1;
					}
					if (Stick.z < 0)
					{
						myposit.y = -1;
					}
				}

				if (Vector2.Distance(myposit,new Vector2(-1,1))<0.1f)
					index = 0;
				else if(Vector2.Distance(myposit,new Vector2(0,1))<0.1f)
					index = 0;
				else if (Vector2.Distance(myposit,new Vector2(1,1))<0.1f)
					index = 1;
				else if(Vector2.Distance(myposit,new Vector2(2,1))<0.1f)
					index = 2;
				else if(Vector2.Distance(myposit,new Vector2(-1,-1))<0.1f)
					index = 3;
				else if(Vector2.Distance(myposit,new Vector2(0,-1))<0.1f)
					index = 4;
				else if(Vector2.Distance(myposit,new Vector2(1,-1))<0.1f)
					index = 5;
				else if(Vector2.Distance(myposit,new Vector2(2,-1))<0.1f)
					index = 6;

				for (int i = 0; i < 7; ++i)
				{
					ui_arr[i].SetActive(false);
					if (i == index)
					{
						ui_arr[i].SetActive(true);
						continue;
					}
				}
				if (InputManager_JHW.AButton())
				{
					SelectMenu = index;
					confirm = true;
					yield return new WaitForSeconds(0.75f);
				}

				yield return new WaitForSeconds(0.25f);
			}
			yield return new WaitForSeconds(0.25f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChange : MonoBehaviour {
	public input_mouse Draw_Rtouch;
	public Material[] MpMaterial;
	private Color Color;
	// Use this for initialization
	private void Awake()
	{
	}
	void Start () {
		switch (input_mouse.curType)
		{
			case 0://아즈라
				Color = new Color(1, 0, 1);
				break;
			case 1://비제
				Color = new Color(0, 1, 0);
				break;
			case 2://델
				Color = new Color(0, 1, 1);
				break;
			case 3://베르베시
				Color = new Color(1, 0, 0);
				break;
			case 4://세이콴
				Color = new Color(1, 1, 0);
				break;
		}
		for (int i=0;i<MpMaterial.Length;++i)
		MpMaterial[i].SetColor("_EmissionColor", Color);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager_JHW.XButtonDown())
		{
			Draw_Rtouch.myType();
			switch (input_mouse.curType)
			{
				case 0://아즈라
					Color = new Color(1, 0, 1);
					break;
				case 1://세이콴
					Color = new Color(1, 1, 0);
					break;
				case 2://비제
					Color = new Color(0, 1, 0);
					break;
				case 3://베르베시
					Color = new Color(1, 0, 0);
					break;
				case 4://델
					Color = new Color(0, 1, 1);
					break;
			}
			for (int i = 0; i < MpMaterial.Length; ++i)
				MpMaterial[i].SetColor("_EmissionColor", Color);

		}
	}
	public Color getMpColor()
	{
		return Color;
	}
}

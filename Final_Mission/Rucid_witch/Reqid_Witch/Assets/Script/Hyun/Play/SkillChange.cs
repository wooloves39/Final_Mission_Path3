using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChange : MonoBehaviour
{
	public input_mouse Draw_Rtouch;
	public Material[] MpMaterial;
	private Color Color;
	public GameObject ChangeParticle;
	public GameObject Hand;
	public GameObject Seikwan;
	public GameObject Dell;
	private Color[] HandColor;
	// Use this for initialization
	private void Awake()
	{
	}
	void Start()
	{
		HandColor = new Color[5];
		HandColor[0] = new Color(1, 0, 1);
		HandColor[1] = new Color(1, 1, 0);
		HandColor[2] = new Color(0, 1, 0);
		HandColor[3]= new Color(1, 0, 0);
		HandColor[4] = new Color(0, 1, 1);
		Color = HandColor[input_mouse.curType];
		for (int i = 0; i < MpMaterial.Length; ++i)
			MpMaterial[i].SetColor("_EmissionColor", Color);
	}

	// Update is called once per frame
	void Update()
	{
		if (InputManager_JHW.XButtonDown())
		{
			Draw_Rtouch.myType();
			Color = HandColor[input_mouse.curType];
			for (int i = 0; i < MpMaterial.Length; ++i)
				MpMaterial[i].SetColor("_EmissionColor", Color);
			ChangeParticle.SetActive(true);
			StartCoroutine(ChangeObject());
		}
	}
	public Color getMpColor()
	{
		return Color;
	}
	IEnumerator ChangeObject()
	{
		yield return new WaitForSeconds(1.0f);
		Dell.SetActive(false);
		Seikwan.SetActive(false);
		Hand.SetActive(false);
		if (input_mouse.curType == 1)
		{
			Seikwan.SetActive(true);
		}
		else if(input_mouse.curType == 4)
		{
			Dell.SetActive(true);
		}
		else
		{
			Hand.SetActive(true);
		}
	}
}

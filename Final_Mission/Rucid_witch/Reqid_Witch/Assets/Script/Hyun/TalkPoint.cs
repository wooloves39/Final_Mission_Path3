﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkPoint : MonoBehaviour
{
	public Dia_Play player;
	private PlayerState MyState;
	//private PlayerState MyState;
	private void Awake()
	{
		MyState = player.transform.parent.GetComponent<PlayerState>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (!player.getPlay())
			{
				MyState.SetMyState(PlayerState.State.Talk);
				player.setPlay(true);

			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
	public enum State{ Nomal, Drawing, Charging, Attack,Damage }

	private State MyState;
	private float ChargingTime;
	private bool back;
	// Use this for initialization
	void Awake () {
		MyState = State.Nomal;
		ChargingTime = 0.0f;

	}
	private void Update()
	{
		if (MyState == State.Charging)
		{
			ChargingTime += Time.deltaTime;
		}
		if (ChargingTime > 5.0f)
		{
			//스킬 실패 기초안
			Debug.Log("스킬 실패");
		}
	}
	public void Back(bool val) { back = val; }
	public void Back() { back = !back; }
	public bool IsBack()
	{
		return back;
	}
	// Update is called once per frame
	public State GetMyState()
	{
		return MyState;
	}
	public void SetMyState(State state)
	{if (state != State.Charging) ChargingTime = 0.0f;
		MyState = state;
	}
	public void SetMyState(int state)
	{
		MyState = (State)state;
	}

}

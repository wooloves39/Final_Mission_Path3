using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
	public enum State{ Nomal, Drawing, Charging, Attack,Damage }
	State MyState;
	// Use this for initialization
	void Start () {
		MyState = State.Nomal;
	}
	
	// Update is called once per frame
	public State GetMyState()
	{
		return MyState;
	}
	public void SetMyState(State state)
	{
		MyState = state;
	}
	public void SetMyState(int state)
	{
		MyState = (State)state;
	}

}

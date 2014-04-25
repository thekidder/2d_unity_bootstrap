using UnityEngine;
using System.Collections;

public abstract class StateListener : MonoBehaviour {
	public Gamestate state;


	// Use this for initialization
	protected void Start () {
		state.Register(this);
		//this.enabled = false; // state will enable us
	}

	public abstract void EnterState(Gamestate.State current, Gamestate.State? last);
	public abstract void LeaveState(Gamestate.State current, Gamestate.State next);
}

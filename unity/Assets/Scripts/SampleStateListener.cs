using UnityEngine;
using System.Collections;

public class SampleStateListener : StateListener {

	new void Start () {
		base.Start();
	}
	
	public void Update () {
		Debug.Log("Updating state " + state.Current);
	}

	public override void EnterState(Gamestate.State current, Gamestate.State? last) {
		Debug.Log ("Entered " + current + "; leaving " + last);
		if(current == Gamestate.State.IDLE) {
			state.Current = Gamestate.State.RUNNING;
		} else {
			state.Current = Gamestate.State.IDLE;
		}
	}
	
	public override void LeaveState(Gamestate.State current, Gamestate.State next) {
		Debug.Log ("Left " + current + "; entering " + next);
		
	}
}

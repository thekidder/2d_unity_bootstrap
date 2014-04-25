using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamestate : MonoBehaviour {
	public enum State {
		RUNNING,
		IDLE,
	}

	public State startState;

	private class ListenerInfo {
		public StateListener listener;
		public bool initialized = false;
	}

	private List<ListenerInfo> listeners = new List<ListenerInfo>();

	private State? nextState;
	private State? currentState;
	private bool canChangeState = true;

	public State? Current {
		get { return currentState; }
		set {
			if(!canChangeState) {
				throw new System.Exception("Can not change state in LeaveState");
			}
			nextState = value;
		}
	}

	public void Register(StateListener state) {
		ListenerInfo info = new ListenerInfo();
		info.listener = state;
		listeners.Add(info);
	}

	void Start () {
		currentState = startState;
		nextState = startState;
	}

	void Update () {
        if(currentState != nextState) {
			State? entering = nextState;
			foreach(ListenerInfo listener in listeners) {
				if(!listener.initialized) {
					continue;
                }
				listener.listener.EnterState((State)entering, (State)currentState);
            }
			currentState = entering;
        }

		// initialize all pending listeners
		foreach(ListenerInfo listener in listeners) {
			if(listener.initialized) {
				continue;
			}
			listener.listener.EnterState((State)currentState, null);
			listener.initialized = true;
            //listener.listener.enabled = true;
        }
    }
    
    void LateUpdate() {
		canChangeState = false;
        if(currentState != nextState) {
			foreach(ListenerInfo listener in listeners) {
				if(!listener.initialized) {
					continue;
				}
				listener.listener.LeaveState((State)currentState, (State)nextState);

            }
        }
		canChangeState = true;
    }
}

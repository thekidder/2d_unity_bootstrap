using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour {
	public Vector3 snapToSize = new Vector3(1f, 1f, 1f);
	public bool snapX = true, snapY = true, snapZ = true;

	void Start () {
		if(Application.isPlaying) {
			this.enabled = false;
		}
	}
	
	void Update () {
		snapToSize.x = Mathf.Abs(snapToSize.x);
		snapToSize.y = Mathf.Abs(snapToSize.y);
		snapToSize.z = Mathf.Abs(snapToSize.z);

		Vector3 current = transform.position;

		if(snapX) {
			current.x += snapToSize.x / 2;
			current.x = (int)(current.x / snapToSize.x) * snapToSize.x;
		}

		if(snapY) {
			current.y += snapToSize.y / 2;
			current.y = (int)(current.y / snapToSize.y) * snapToSize.y;
		}

		if(snapZ) {
			current.z += snapToSize.z / 2;
			current.z = (int)(current.z / snapToSize.z) * snapToSize.z;
		}

		transform.position = current;
	}
}

using UnityEngine;
using System.Collections;

public class TouchableObject : MonoBehaviour {

	public float onTouchMoveSpeed = .5f;
		

	public void OnTouched(RaycastHit2D hit) {
	}

	public void OnDrag(DragSummary dragSummary) {
		this.transform.position += onTouchMoveSpeed * new Vector3 (dragSummary.direction.x, dragSummary.direction.y, 0f);
	}

}

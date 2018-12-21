using UnityEngine;

public class SlerpMoveTo : MonoBehaviour
{
	public Vector3 targetPosition;
	public float moveSpeed = 0.02f;
	public Vector3Constraints Constraints;

	private void Update()
	{
		Vector3 newPosition = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

		if (Constraints.FreezeX) newPosition.x = transform.position.x;
		if (Constraints.FreezeY) newPosition.y = transform.position.y;
		if (Constraints.FreezeZ) newPosition.z = transform.position.z;

		transform.position = newPosition;
	}
}

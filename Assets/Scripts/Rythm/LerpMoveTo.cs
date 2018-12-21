using UnityEngine;

public class LerpMoveTo : MonoBehaviour
{
	public Vector3 targetPosition;
	public float moveSpeed = 0.02f;
	public Vector3Constraints Constraints;

	private void Update()
	{
		Vector3 newPosition = Vector3.zero;
		newPosition.x = (Constraints.FreezeX) ? transform.position.x : Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * moveSpeed);
		newPosition.y = (Constraints.FreezeY) ? transform.position.y : Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * moveSpeed);
		newPosition.z = (Constraints.FreezeZ) ? transform.position.z : Mathf.Lerp(transform.position.z, targetPosition.z, Time.deltaTime * moveSpeed);

		transform.position = newPosition;
	}
}

[System.Serializable]
public class Vector3Constraints
{
	public bool FreezeX = false;
	public bool FreezeY = false;
	public bool FreezeZ = false;
}

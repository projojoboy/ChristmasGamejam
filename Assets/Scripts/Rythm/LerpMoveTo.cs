using System.Collections;
using UnityEngine;

public class LerpMoveTo : MonoBehaviour
{
	public Vector3 targetPosition;
	public float timeToMove = 3f;
	public Vector3Constraints Constraints;

	private void Start()
	{
		StartCoroutine(MoveToPosition(targetPosition, timeToMove));
	}

	public IEnumerator MoveToPosition(Vector3 targetPosition, float timeToMove)
	{
		Vector3 finalPosition = Vector3.zero;
		float time = 0f;
		while(time < 1)
		{
			time += Time.deltaTime / timeToMove;
			finalPosition.x = (Constraints.FreezeX) ? transform.position.x : Mathf.Lerp(transform.position.x, targetPosition.x, time);
			finalPosition.y = (Constraints.FreezeY) ? transform.position.y : Mathf.Lerp(transform.position.y, targetPosition.y, time);
			finalPosition.z = (Constraints.FreezeZ) ? transform.position.z : Mathf.Lerp(transform.position.z, targetPosition.z, time);
			transform.position = finalPosition;
			yield return null;
		}
	}
}

[System.Serializable]
public class Vector3Constraints
{
	public bool FreezeX = false;
	public bool FreezeY = false;
	public bool FreezeZ = false;
}

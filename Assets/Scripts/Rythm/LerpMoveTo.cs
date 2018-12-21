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
		Vector3 startPosition = transform.position;
		float time = 0f;
		while(time < 1)
		{
			time += Time.deltaTime / timeToMove;
			finalPosition.x = (Constraints.FreezeX) ? transform.position.x : Easing.Ease(EaseType.QuadIn, startPosition.x, targetPosition.x, time);
			finalPosition.y = (Constraints.FreezeY) ? transform.position.y : Easing.Ease(EaseType.QuadIn, startPosition.y, targetPosition.y, time);
			finalPosition.z = (Constraints.FreezeZ) ? transform.position.z : Easing.Ease(EaseType.QuadIn, startPosition.z, targetPosition.z, time);
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

using UnityEngine;

public class Rythm : MonoBehaviour
{
	public int bpm;
	public float secondsToReachTarget = 2f;
	public ObjectSpawner objectSpawner;

	private float _secondsPerBeat;

	private void Awake()
	{
		_secondsPerBeat = 60f / bpm;
	}

	private void Start()
	{
		InvokeRepeating("NextBeat", secondsToReachTarget, _secondsPerBeat);
	}

	private void NextBeat()
	{
		Debug.Log("TICK");
		objectSpawner.SpawnObject();
	}
}

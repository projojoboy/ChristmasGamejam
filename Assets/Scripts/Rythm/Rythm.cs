using UnityEngine;

public class Rythm : MonoBehaviour
{
	public int bpm;

	private float _secondsPerBeat;

	private void Awake()
	{
		_secondsPerBeat = 60f / bpm;
	}

	private void Start()
	{
		InvokeRepeating("NextBeat", 0f, _secondsPerBeat);
	}

	private void NextBeat()
	{
		Debug.Log("Tick");
	}
}

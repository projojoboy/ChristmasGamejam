using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtPosition : MonoBehaviour
{
	public string destroyAudioObjectName = "HitAudio";
	private AudioSource _destroyAudio;
	public float yPositionToDestroy = -4;

	private void Awake()
	{
		_destroyAudio = GameObject.Find(destroyAudioObjectName).GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (transform.position.y <= yPositionToDestroy)
		{
			_destroyAudio.Play();
			Destroy(gameObject);

			CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
			if (cameraShake != null)
				cameraShake.StartShake();
		}
	}
}
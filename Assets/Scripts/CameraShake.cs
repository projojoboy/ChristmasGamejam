using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Vector3 maxOffSet;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private float shakeTime;
    [SerializeField] private float shakeDuration;

    private Transform newPos;
    private bool shakeEnabled = false;

    public void StartShake()
    {
        StartCoroutine(EnableShake());
    }

    IEnumerator ScreenShake()
    {
        if (shakeEnabled)
        {
            yield return new WaitForSeconds(shakeTime);
            var offsetX = Random.Range(-maxOffSet.x, maxOffSet.x);
            var offsetY = Random.Range(-maxOffSet.y, maxOffSet.y);
            var offsetZ = Random.Range(-maxOffSet.z, maxOffSet.z);
            transform.position = new Vector3(startPos.x + offsetX, startPos.y + offsetY, startPos.z + offsetZ);
            StartCoroutine(ScreenShake());
        }
    }

    IEnumerator EnableShake()
    {
        shakeEnabled = true;
        StartCoroutine(ScreenShake());
        yield return new WaitForSeconds(shakeDuration);
        shakeEnabled = false;
        transform.position = startPos;
    }
}

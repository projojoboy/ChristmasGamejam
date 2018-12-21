using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnableObjects;

    [SerializeField] private int minRange = -9, maxRange = 9;

    public void SpawnObject()
    {
        //spawn 9
        int randInt = Random.Range(minRange, maxRange);
        int randGO = Random.Range(0, spawnableObjects.Length);

        Instantiate(spawnableObjects[randGO], new Vector2(transform.position.x + randInt, transform.position.y), Quaternion.identity);
    }
}

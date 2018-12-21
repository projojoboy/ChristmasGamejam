﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    public int curPoints;
    public int highscore;

    private void Start()
    {
        curPoints = 0;
        highscore = PlayerPrefs.GetInt("highscore");
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "CollectableObject")
        {
            //Add points
            curPoints++;
            //Destroy CollectableObject
            Destroy(coll.gameObject);
            //Add Lives?
        }
    }

    public void CheckHighscore()
    {
        if (curPoints > highscore)
            PlayerPrefs.SetInt("highscore", curPoints);
    }
}

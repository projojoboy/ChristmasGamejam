using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    public int curPoints;
    public int highscore;

    [SerializeField] private Text scoreText;

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

            scoreText.text = "Score: " + curPoints;
        }
    }

    public void CheckHighscore()
    {
        if (curPoints > highscore)
            PlayerPrefs.SetInt("highscore", curPoints);
    }
}

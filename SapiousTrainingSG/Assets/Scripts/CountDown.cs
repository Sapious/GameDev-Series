using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public int timeLeft;
    int Seconds;
    int minutes;
    bool takingAway = false;
    public TMP_Text timeDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && timeLeft > 0)
        {
            StartCoroutine(TakeAway());
        }
    }

    IEnumerator TakeAway()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        Seconds = timeLeft % 60;
        minutes = timeLeft / 60;
        timeDisplay.text = minutes + " : " + Seconds;
        takingAway = false;
    }
}

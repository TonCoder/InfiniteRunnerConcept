using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour {
    [SerializeField] private TMP_Text _clockTxt;
    private float _elapsedTime = 0;
    // Update is called once per frame
    float seconds;
    
    void Update () {
        if (GameManager.instance.IsGameStarted ()) {
            RunClock ();
        }
    }

    public string Timer () {
        _elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt (_elapsedTime / 60F);
        seconds += Time.deltaTime;

        if (seconds >= 60) {
            seconds = 0;
        }
        return string.Format ("{0:00}:{1:00}", minutes, seconds);
    }

    public void RunClock () {
        _clockTxt.text = Timer ();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour {

    public float timer;

    [SerializeField]
    private TextMeshPro timerText;

    public CarnivalScores scores;
    public bool gameIsWon;
    public bool playAgain;

    public GameObject tryAgainButton;

	// Use this for initialization
	void Start () {
        timer = 45;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameIsWon){
            tryAgainButton.SetActive(false);
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + timer.ToString("F0");
        }
        else
        {
            timer = 45;
            timerText.text = "You won!";
            tryAgainButton.SetActive(true);
        }
	}

    public void TryAgain()
    {
        gameIsWon = false;
        scores.gameOver();
    }
}

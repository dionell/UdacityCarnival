using System;
using UnityEngine;
using TMPro;

public class CarnivalScores : MonoBehaviour {

	[SerializeField]
	private int TeddyBearPointsMin = 2000;

	[SerializeField]
	private GameObject TeddyBear;

    [SerializeField]
    private GameObject TeddyBearOnBoxes;

	[SerializeField]
	private TextMeshPro plinkoScore;
	[SerializeField]
	private TextMeshPro wheelScore;
	[SerializeField]
	private TextMeshPro coinScore;

	public static CarnivalScores Instance;

	private int plinkoPoints;
	private int wheelPoints;
	private int coinPoints;

    public CountdownTimer timer;
    public AudioSource scoreReset;
    public AudioSource winGame;

	void Awake() {
		if (Instance == null)
			Instance = this;

		TeddyBear.SetActive(false);
	}

	void OnDestroy() {
		if (Instance = this)
			Instance = null;
	}

	// Update is called once per frame
	void Update () {
		plinkoScore.text = "Plinko: " + plinkoPoints.ToString("0000");
		wheelScore.text = "Wheel: " + wheelPoints.ToString("0000");
		coinScore.text = "Coins: " + coinPoints.ToString("0000");

        if (timer.timer <= 0)
        {
            gameOver();
        }

        if (plinkoPoints + wheelPoints + coinPoints >= TeddyBearPointsMin) {
            win();
		}
	}

	public void IncrementPlinkoScore(float points) {
		plinkoPoints += (int) points;
	}

	public void IncrementWheelScore(float points) {
		wheelPoints += (int) points;
	}

	public void IncrementCoinScore() {
		coinPoints += 500;
	}

    public void gameOver()
    {
        TeddyBear.SetActive(false);
        TeddyBearOnBoxes.SetActive(true);
        scoreReset.Play();
        timer.timer = 45;
        plinkoPoints = 0;
        wheelPoints = 0;
        coinPoints = 0;
    }

    void win()
    {
        timer.gameIsWon = true;
        TeddyBear.SetActive(true);
        TeddyBearOnBoxes.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GrabHighScore : MonoBehaviour {

	private LevelInformation levelInfo;
	private Text[] HighScores = new Text[5];
	public Text highScore1;
	public Text highScore2;
	public Text highScore3;
	public Text highScore4;
	public Text highScore5;
	private int hScore1;
	private int hScore2;
	private int hScore3;
	private int hScore4;
	private int hScore5;
	private int[] hScores = new int[5];

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		int highScoreReplace = 0;
		Boolean highScoreAchieved = false;
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
		hScore1 = PlayerPrefs.GetInt("HighScore1", 0);
		hScore2 = PlayerPrefs.GetInt("HighScore2", 0);
		hScore3 = PlayerPrefs.GetInt("HighScore3", 0);
		hScore4 = PlayerPrefs.GetInt("HighScore4", 0);
		hScore5 = PlayerPrefs.GetInt("HighScore5", 0);
		HighScores[0] = highScore1;
		HighScores[1] = highScore2;
		HighScores[2] = highScore3;
		HighScores[3] = highScore4;
		HighScores[4] = highScore5;
		hScores[0] = hScore1;
		hScores[1] = hScore2;
		hScores[2] = hScore3;
		hScores[3] = hScore4;
		hScores[4] = hScore5;
		for (int i = 0; i < 5; i++)
		{
			if (levelInfo.totalScore > hScores[i])
            {
				highScoreReplace = i;
				highScoreAchieved = true;
				break;
            }
        }

		if (highScoreAchieved)
        {
			for (int h = 4; h > highScoreReplace; h--)
            {
				hScores[h] = hScores[h - 1];
            }
			hScores[highScoreReplace] = levelInfo.totalScore;
        }

		for (int j = 0; j < 5; j++)
        {
			HighScores[j].text = (j + 1).ToString() + ". " + hScores[j];
        }

		PlayerPrefs.SetInt("HighScore1", hScores[0]);
		PlayerPrefs.SetInt("HighScore2", hScores[1]);
		PlayerPrefs.SetInt("HighScore3", hScores[2]);
		PlayerPrefs.SetInt("HighScore4", hScores[3]);
		PlayerPrefs.SetInt("HighScore5", hScores[4]);
	}
}

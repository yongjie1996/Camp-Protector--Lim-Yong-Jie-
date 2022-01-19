using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

	private LevelInformation levelInfo;

	// Use this for initialization
	void Start () {
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
	}
	
	// Update is called once per frame
	void Update () {
		int minutes = (int)levelInfo.levelTime / 60;
		int second = (int)levelInfo.levelTime % 60;
		string seconds;
		if (second == 0)
        {
			seconds = "00";
        }
		else if (second < 10)
        {
			seconds = "0" + second.ToString();
		}
		else
        {
			seconds = second.ToString();
        }
		gameObject.GetComponent<Text>().text = minutes + ":" + seconds;
	}
}

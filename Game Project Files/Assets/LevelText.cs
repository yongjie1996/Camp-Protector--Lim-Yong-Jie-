using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	private LevelInformation levelInfo;

	// Use this for initialization
	void Start () 
	{
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
	}

	void Update ()
    {
		gameObject.GetComponent<Text>().text = "Level " + levelInfo.level;
	}
	
}

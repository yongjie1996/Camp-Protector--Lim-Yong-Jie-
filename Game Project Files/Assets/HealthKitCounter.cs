using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKitCounter : MonoBehaviour {
	private LevelInformation levelInfo;
	// Use this for initialization
	void Start () {
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = "x" + levelInfo.healthKitCount;
	}
}

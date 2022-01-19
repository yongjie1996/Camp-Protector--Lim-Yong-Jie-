using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private LevelInformation levelInfo;
    private Text textbox = null;

    private void Awake()
    {
        levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
        textbox = GetComponent<Text>();
    }

    void Update()
    {
        textbox.text = "Score: " + levelInfo.score;
    }
}
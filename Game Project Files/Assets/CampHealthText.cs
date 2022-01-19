using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CampHealthText : MonoBehaviour {
	private Text textbox = null;
	private Health ThisHealth = null;
	private float maxHealth;
	private float currentHealth;
	private LevelInformation levelInfo;

	private void Awake()
	{
		textbox = GetComponent<Text>();
		ThisHealth = GameObject.FindGameObjectWithTag("CampHitBox").GetComponent<Health>();
		levelInfo = GameObject.FindWithTag("LevelInformation").GetComponent<LevelInformation>();
	}

	void Start()
    {
		maxHealth = levelInfo.CampHealthCalculate();
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		currentHealth = ThisHealth.HealthPoints;
		int cHealth = (int)Math.Round(currentHealth);
		int mHealth = (int)maxHealth;
		textbox.text = "Camp: " + cHealth + " / " + mHealth;
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += Loadedscene;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= Loadedscene;
	}

	void Loadedscene(Scene scene, LoadSceneMode mode)
	{
		scene = SceneManager.GetActiveScene();

		if (scene.buildIndex == 3)
		{
			ThisHealth = GameObject.FindGameObjectWithTag("CampHitBox").GetComponent<Health>();
			maxHealth = levelInfo.CampHealthCalculate();
			currentHealth = maxHealth;
		}
	}
}

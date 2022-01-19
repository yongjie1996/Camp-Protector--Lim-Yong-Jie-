using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarPlayer : MonoBehaviour {
	[SerializeField]
	private Image foregroundImage;
	Health ThisHealth = null;
	private float maxHealth;
	private float currentHealth;
	private LevelInformation levelInfo;

	private void Awake()
	{
		levelInfo = GameObject.FindWithTag("LevelInformation").GetComponent<LevelInformation>();
		ThisHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
	}

	void Start()
	{
		maxHealth = levelInfo.PlayerHealthCalculate();
		currentHealth = maxHealth;
	}

	void Update()
	{
		currentHealth = ThisHealth.HealthPoints;
		foregroundImage.fillAmount = currentHealth / maxHealth;
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
			ThisHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
			maxHealth = levelInfo.PlayerHealthCalculate();
			currentHealth = maxHealth;
		}
	}
}

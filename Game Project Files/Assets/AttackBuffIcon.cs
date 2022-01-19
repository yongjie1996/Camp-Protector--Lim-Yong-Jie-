using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AttackBuffIcon : MonoBehaviour {
	[SerializeField]
	private Image foregroundImage;
	[SerializeField]
	private Image backgroundImage;
	private Consumables consumables;
	private float maxTime = 60f;
	private float currentTime;
	// Use this for initialization
	private void Awake () 
	{
		consumables = GameObject.FindGameObjectWithTag("Player").GetComponent<Consumables>();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = consumables.attackBuffTimer;
		foregroundImage.fillAmount = currentTime / maxTime;
		backgroundImage.fillAmount = currentTime / maxTime;
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
			consumables = GameObject.FindGameObjectWithTag("Player").GetComponent<Consumables>();
		}
	}
}

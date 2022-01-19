using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	[SerializeField]
	private Image foregroundImage;
	private Camera camera;
	Health ThisHealth = null;
	private float maxHealth;
	private float currentHealth;
	private LevelInformation levelInfo;

	private void Awake()
    {
		levelInfo = GameObject.FindWithTag("LevelInformation").GetComponent<LevelInformation>();
		camera = Camera.main;
		ThisHealth = GetComponentInParent<Health>();
	}

	void Start()
    {
		if (gameObject.tag == "GoblinHP")
		{
			maxHealth = levelInfo.goblinHealthCalculate();
		}
		else if (gameObject.tag == "WolfHP")
        {
			maxHealth = levelInfo.wolfHealthCalculate();
		}
		currentHealth = maxHealth;
	}

	void Update()
    {
		transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);
		currentHealth = ThisHealth.HealthPoints;
		foregroundImage.fillAmount = currentHealth / maxHealth;
    }
}

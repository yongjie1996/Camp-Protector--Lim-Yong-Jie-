using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	public float maxHealth;
	private float previousHealth;
	public UnityEvent OnHealthChanged;
	public string SpawnPoolTag = string.Empty;
	private ObjectPool Pool = null;
	private Transform ThisTransform = null;
	private BotAI bot = null;
	private LevelInformation levelInfo;
	public Boolean AttackUpBuff = false;
	public Boolean DefenseUpBuff = false;
	public float HealthPoints
	{
		get { return _HealthPoints; }
		set
		{
			_HealthPoints = value;
			OnHealthChanged.Invoke();
			if (_HealthPoints <= 0f)
			{
				bot = GetComponent<BotAI>();
				if (bot != null)
                {
					bot.PlayDead();
					if (gameObject.tag == "Wolf" || gameObject.tag == "Goblin")
					{
						if (previousHealth > 0f)
						{
							levelInfo.score += 100 + (((levelInfo.level - 1) * (levelInfo.level - 1)) * 50);
							levelInfo.totalScore += 100 + (((levelInfo.level - 1) * (levelInfo.level - 1)) * 50);
						}
					}
					Invoke("Die", 2f);
				}
				else
                {
					Die();
                }
			}
		}
	}
	[SerializeField]
	private float _HealthPoints = 100f;
	private void Awake()
	{
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
		ThisTransform = GetComponent<Transform>();
		if (SpawnPoolTag.Length > 0)
			Pool = GameObject.FindWithTag(SpawnPoolTag).
			GetComponent<ObjectPool>();
	}

	void Start()
	{
		if (gameObject.tag == "Player")
		{
			_HealthPoints = levelInfo.PlayerHealthCalculate();
			HealthPoints = _HealthPoints;
			maxHealth = HealthPoints;
		}
		else if (gameObject.tag == "CampHitBox")
		{
			_HealthPoints = levelInfo.CampHealthCalculate();
			HealthPoints = _HealthPoints;
		}
		else if (gameObject.tag == "Goblin")
		{
			_HealthPoints = levelInfo.goblinHealthCalculate();
			HealthPoints = _HealthPoints;
		}
		else if (gameObject.tag == "Wolf")
		{
			_HealthPoints = levelInfo.wolfHealthCalculate();
			HealthPoints = _HealthPoints;
		}
	}

	public void TakeDamage(float damage)
    {
		if (AttackUpBuff && gameObject.tag == "Wolf" || AttackUpBuff && gameObject.tag == "Goblin")
        {
			damage *= 1.5f;
        }
		if (DefenseUpBuff && gameObject.tag == "Player")
        {
			damage /= 2;
        }
		previousHealth = HealthPoints;
		HealthPoints -= damage;
		if (HealthPoints > 0 && GetComponent<BotAI>() != null)
        {
			GetComponent<BotAI>().PlayDamage();
		}
    }

	public void HealDamage(float damage)
    {
		previousHealth = HealthPoints;
		HealthPoints += damage;
		if (HealthPoints > maxHealth)
        {
			HealthPoints = maxHealth;
        }
	}

	private void Die()
	{
		if (Pool != null)
		{
			Pool.Despawn(ThisTransform);
			if (gameObject.tag == "Goblin")
            {
				HealthPoints = levelInfo.goblinHealthCalculate();
			}
			else if (gameObject.tag == "Wolf")
            {
				HealthPoints = levelInfo.wolfHealthCalculate();
			}
		}

		else
        {
			if (gameObject.tag == "CampHitBox" || gameObject.tag == "Player")
            {
				levelInfo.LoadHighScoreScene();
			}
        }
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
			levelInfo = GameObject.FindWithTag("LevelInformation").GetComponent<LevelInformation>();
		}
	}
}

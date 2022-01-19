using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Consumables : MonoBehaviour {

	public GameObject player;
	private FirstPersonController fpsControl;
	private LevelInformation levelInfo;
	private Health health;
	public float attackBuffTimer = 0f;
	public float defenseBuffTimer = 0f;
	public float speedBuffTimer = 0f;
	private Boolean speedUpBuff = false;

	// Use this for initialization
	void Start () 
	{
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
		fpsControl = player.GetComponent<FirstPersonController>();
		health = gameObject.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			if (levelInfo.healthKitCount > 0)
            {
				int healDamage = (int)health.maxHealth / 4;
				health.HealDamage(healDamage);
				levelInfo.healthKitCount--;
				levelInfo.healthKitCountText.text = "Have: " + levelInfo.healthKitCount;
			}
        }

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (levelInfo.attackUpCount > 0)
			{
				health.AttackUpBuff = true;
				attackBuffTimer = 60f;
				levelInfo.attackUpCount--;
				levelInfo.attackUpCountText.text = "Have: " + levelInfo.attackUpCount;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (levelInfo.defenseUpCount > 0)
			{
				health.DefenseUpBuff = true;
				defenseBuffTimer = 60f;
				levelInfo.defenseUpCount--;
				levelInfo.defenseUpCountText.text = "Have: " + levelInfo.defenseUpCount;
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			if (levelInfo.speedUpCount > 0)
			{
				if (speedUpBuff == false)
                {
					fpsControl.m_WalkSpeed *= 1.5f;
					fpsControl.m_RunSpeed *= 1.5f;
				}
				speedUpBuff = true;				
				speedBuffTimer = 60f;
				levelInfo.speedUpCount--;
				levelInfo.speedUpCountText.text = "Have: " + levelInfo.speedUpCount;
			}
		}

		if (attackBuffTimer > 0f)
        {
			attackBuffTimer -= Time.deltaTime;
        }

		if (attackBuffTimer < 0f && health.AttackUpBuff == true)
        {
			health.AttackUpBuff = false;
        }

		if (defenseBuffTimer > 0f)
		{
			defenseBuffTimer -= Time.deltaTime;
		}

		if (defenseBuffTimer < 0f && health.DefenseUpBuff == true)
		{
			health.DefenseUpBuff = false;
		}

		if (speedBuffTimer > 0f)
		{
			speedBuffTimer -= Time.deltaTime;
		}

		if (speedBuffTimer < 0f && speedUpBuff == true)
		{
			speedUpBuff = false;
			fpsControl.m_WalkSpeed = 5f;
			fpsControl.m_RunSpeed = 10f;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

	public int level;
	public int score;
	public int totalScore;

	public int playerHPUpgrade;
	public int playerHPUpgradeCost;

	public int campHPUpgrade;
	public int campHPUpgradeCost;

	public int machineGunLevel;
	public int machineGunUpgradeCost;

	public int rifleLevel;
	public int rifleUpgradeCost;

	public int handgunLevel;
	public int handgunUpgradeCost;

	public int shotgunLevel;
	public int shotgunUpgradeCost;

	public int turretLevel;
	public int turretUpgradeCost;

	public int healthKitCount;
	public int attackUpCount;
	public int defenseUpCount;
	public int speedUpCount;

	public SaveData (LevelInformation levelInfo)
    {
		level = levelInfo.level;
		score = levelInfo.score;
		totalScore = levelInfo.totalScore;

		playerHPUpgrade = levelInfo.playerHPUpgrade;
		playerHPUpgradeCost = levelInfo.playerHPUpgradeCost;

		campHPUpgrade = levelInfo.campHPUpgrade;
		campHPUpgradeCost = levelInfo.campHPUpgradeCost;

		machineGunLevel = levelInfo.machineGunLevel;
		machineGunUpgradeCost = levelInfo.machineGunUpgradeCost;

		rifleLevel = levelInfo.rifleLevel;
		rifleUpgradeCost = levelInfo.rifleUpgradeCost;

		handgunLevel = levelInfo.handgunLevel;
		handgunUpgradeCost = levelInfo.handgunUpgradeCost;

		shotgunLevel = levelInfo.shotgunLevel;
		shotgunUpgradeCost = levelInfo.shotgunUpgradeCost;

		turretLevel = levelInfo.turretLevel;
		turretUpgradeCost = levelInfo.turretUpgradeCost;

		healthKitCount = levelInfo.healthKitCount;
		attackUpCount = levelInfo.attackUpCount;
		defenseUpCount = levelInfo.defenseUpCount;
		speedUpCount = levelInfo.speedUpCount;
    }
}

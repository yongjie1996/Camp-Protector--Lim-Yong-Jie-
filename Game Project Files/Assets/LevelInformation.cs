using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


[System.Serializable]
public class LevelInformation : MonoBehaviour { 

	private static LevelInformation levelInstance;

	public GameObject scoreObject;
	public ScoreText scoretext;

	public float levelTime;
	public int level;
	public int lastScore;
	public int score;
	public int totalScore;

	public GameObject player;

	public Text SaveText;

	public int playerHPUpgrade;
	public int playerHPUpgradeCost;
	public Text playerHPText;
	public Text PlayerMaxHP;

	public int campHPUpgrade;
	public int campHPUpgradeCost;
	public Text campHPText;
	public Text CampMaxHP;

	public int machineGunLevel;
	public int machineGunUpgradeCost;
	public Text machineGunText;
	public Text machineGunAttack;

	public int rifleLevel;
	public int rifleUpgradeCost;
	public Text rifleText;
	public Text rifleAttack;

	public int handgunLevel;
	public int handgunUpgradeCost;
	public Text handgunText;
	public Text handgunAttack;

	public int shotgunLevel;
	public int shotgunUpgradeCost;
	public Text shotgunText;
	public Text shotgunAttack;

	public int turretLevel;
	public int turretUpgradeCost;
	public Text turretText;
	public Text turretAttack;

	public int healthKitCount;
	public int attackUpCount;
	public int defenseUpCount;
	public int speedUpCount;

	public Text healthKitCostText;
	public Text attackUpCostText;
	public Text defenseUpCostText;
	public Text speedUpCostText;

	public Text healthKitCountText;
	public Text attackUpCountText;
	public Text defenseUpCountText;
	public Text speedUpCountText;

	public int consumableCost;

	public GameObject Goblin;
	public GameObject Wolf;

	public int sceneIndex;
	public Slider slider;
	public Text text;

	public GameObject PlayerUI;
	public GameObject LoadingBar;
	public GameObject PrimaryUI;
	public GameObject UpgradeUI;

	public int PlayerHealthCalculate ()
    {
		int totalPlayerHealth = 100 + ((level - 1) * 30 + playerHPUpgrade * 20);
		return totalPlayerHealth;
    }

	public int CampHealthCalculate ()
    {
		int totalCampHealth = 5000 + (level - 1) * 500 + campHPUpgrade * 500;
		return totalCampHealth;
    }

	public int machineGunAttackCalculate ()
    {
		int attack = 10 + machineGunLevel * 5;
		return attack;
    }

	public int rifleAttackCalculate()
    {
        int attack = 50 + rifleLevel * 25;
        return attack;
    }

	public int handgunAttackCalculate()
    {
		int attack = 25 + handgunLevel * 15;
		return attack;
    }

	public int shotgunAttackCalculate()
    {
		int attack = 15 + shotgunLevel * 8;
		return attack;
    }

	public int turretAttackCalculate()
    {
		int attack = 25 + turretLevel * 25;
		return attack;
    }

	public float goblinHealthCalculate()
    {
		float health = 200f + (level - 1) * 100f;
		return health;
    }

	public int goblinAttackCalculate()
    {
		int attack = 20 + (level - 1) * 20;
		return attack;
    }

	public float wolfHealthCalculate()
    {
		float health = 100f + (level - 1) * 60f;
		return health;
    }

	public int wolfAttackCalculate()
    {
		int attack = 10 + (level - 1) * 12;
		return attack;
    }

	public void raisePlayerHP()
    {
		if (score >= playerHPUpgradeCost)
		{
			score -= playerHPUpgradeCost;
			updateScore();
			playerHPUpgrade++;
			updatePlayerHPCost();
			PlayerMaxHP.text = "Player HP: " + PlayerHealthCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	void updatePlayerHPCost()
	{
		playerHPUpgradeCost += playerHPUpgradeCost;
		playerHPText.text = "Cost: " + playerHPUpgradeCost;
	}

	public void raiseCampHP()
    {
		if (score >= campHPUpgradeCost)
		{
			score -= campHPUpgradeCost;
			updateScore();
			campHPUpgrade++;
			updateCampHPCost();
			CampMaxHP.text = "Camp HP: " + CampHealthCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	void updateCampHPCost()
	{
		campHPUpgradeCost += campHPUpgradeCost;
		campHPText.text = "Cost: " + campHPUpgradeCost;
	}

	public void raiseMachineGunAttack()
    {
		if (score >= machineGunUpgradeCost)
        {
			score -= machineGunUpgradeCost;
			updateScore();
			machineGunLevel++;
			updateMachineGunCost();
			machineGunAttack.text = "Attack: " + machineGunAttackCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}		
    }

	void updateMachineGunCost()
    {
		machineGunUpgradeCost *= 2;
		machineGunText.text = "Cost: " + machineGunUpgradeCost;
    }

	public void raiseRifleAttack()
    {
		if (score >= rifleUpgradeCost)
		{
			score -= rifleUpgradeCost;
			updateScore();
			rifleLevel++;
			updateRifleCost();
			rifleAttack.text = "Attack: " + rifleAttackCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	void updateRifleCost()
	{
		rifleUpgradeCost *= 2;
		rifleText.text = "Cost: " + rifleUpgradeCost;
	}

	public void raiseHandgunAttack()
    {
		if (score >= handgunUpgradeCost)
		{
			score -= handgunUpgradeCost;
			updateScore();
			handgunLevel++;
			updateHandgunCost();
			handgunAttack.text = "Attack: " + handgunAttackCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	void updateHandgunCost()
	{
		handgunUpgradeCost *= 2;
		handgunText.text = "Cost: " + handgunUpgradeCost;
	}

	public void raiseShotgunAttack()
    {
		if (score >= shotgunUpgradeCost)
		{
			score -= shotgunUpgradeCost;
			updateScore();
			shotgunLevel++;
			updateShotgunCost();
			shotgunAttack.text = "Attack: " + shotgunAttackCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}
    }

	void updateShotgunCost()
	{
		shotgunUpgradeCost *= 2;
		shotgunText.text = "Cost: " + shotgunUpgradeCost;
	}

	public void raiseTurretAttack()
    {
		if (score >= turretUpgradeCost)
		{
			score -= turretUpgradeCost;
			updateScore();
			turretLevel++;
			updateTurretCost();
			turretAttack.text = "Turret Damage: " + turretAttackCalculate();
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	void updateTurretCost()
    {
		turretUpgradeCost *= 2;
		turretText.text = "Cost: " + turretUpgradeCost;
    }

	public void purchaseHealthKit()
    {
		if (score >= consumableCost)
        {
			score -= consumableCost;
			updateScore();
			healthKitCount++;
			healthKitCountText.text = "Have: " + healthKitCount;
			SaveText.text = "Press Save button to save your game progress.";
		}
    }

	public void purchaseAttackUp()
	{
		if (score >= consumableCost)
		{
			score -= consumableCost;
			updateScore();
			attackUpCount++;
			attackUpCountText.text = "Have: " + attackUpCount;
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	public void purchaseDefenseUp()
	{
		if (score >= consumableCost)
		{
			score -= consumableCost;
			updateScore();
			defenseUpCount++;
			defenseUpCountText.text = "Have: " + defenseUpCount;
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	public void purchaseSpeedUp()
	{
		if (score >= consumableCost)
		{
			score -= consumableCost;
			updateScore();
			speedUpCount++;
			speedUpCountText.text = "Have: " + speedUpCount;
			SaveText.text = "Press Save button to save your game progress.";
		}
	}

	void updateScore()
    {
		lastScore = score;
	}

	void LoadUpgradeScene() // triggers loading Upgrade Scene when time in main game reaches 0
	{
		updateUpgradeText();
		if (GameObject.FindGameObjectWithTag("PrimaryUI").activeSelf)
        {
			GameObject.FindGameObjectWithTag("PrimaryUI").SetActive(false);
		}	
		player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		LoadingBar.SetActive(true);
		StartCoroutine(LoadAsynchronously());
		LoadingBar.SetActive(false);
		UpgradeUI.SetActive(true);
	}

	public void LoadGameScene() // trigger loading Main Game from Upgrade Scene with a button
	{
		level++;
		levelTime = 120f;
		UpgradeUI.SetActive(false);
		LoadingBar.SetActive(true);
		StartCoroutine(MainLoadAsynchronously());
		LoadingBar.SetActive(false);
		PrimaryUI.SetActive(true);
	}

	public void LoadHighScoreScene()
    {
		GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		GameObject.FindGameObjectWithTag("PrimaryUI").SetActive(false);
		LoadingBar.SetActive(true);
		StartCoroutine(HighScoreLoadAsynchronously());
		LoadingBar.SetActive(false);
	}

	IEnumerator LoadAsynchronously() // Load Upgrade Scene from Main Game
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			text.text = (progress * 100) + "%";

			yield return null;
		}
	}

	IEnumerator MainLoadAsynchronously() // Load Main Game from Upgrade Scene
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(3);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			text.text = (progress * 100) + "%";

			yield return null;
		}
	}

	IEnumerator HighScoreLoadAsynchronously()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(6);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			text.text = (progress * 100) + "%";

			yield return null;
		}
	}

	public void SaveGame()
    {
		SaveSystem.SaveGame(this);
		SaveText.text = "Game has been saved successfully.";
    }

	public void LoadGame()
    {
		SaveData data = SaveSystem.LoadGame();

		level = data.level;
		score = data.score;
		totalScore = data.totalScore;

		playerHPUpgrade = data.playerHPUpgrade;
		playerHPUpgradeCost = data.playerHPUpgradeCost;

		campHPUpgrade = data.campHPUpgrade;
		campHPUpgradeCost = data.campHPUpgradeCost;

		machineGunLevel = data.machineGunLevel;
		machineGunUpgradeCost = data.machineGunUpgradeCost;

		rifleLevel = data.rifleLevel;
		rifleUpgradeCost = data.rifleUpgradeCost;

		handgunLevel = data.handgunLevel;
		handgunUpgradeCost = data.handgunUpgradeCost;

		shotgunLevel = data.shotgunLevel;
		shotgunUpgradeCost = data.shotgunUpgradeCost;

		turretLevel = data.turretLevel;
		turretUpgradeCost = data.turretUpgradeCost;

		healthKitCount = data.healthKitCount;
		attackUpCount = data.attackUpCount;
		defenseUpCount = data.defenseUpCount;
		speedUpCount = data.speedUpCount;

		playerHPText.text = "Cost: " + playerHPUpgradeCost;
		PlayerMaxHP.text = "Player HP: " + PlayerHealthCalculate();

		campHPText.text = "Cost: " + campHPUpgradeCost;
		CampMaxHP.text = "Camp HP: " + CampHealthCalculate();

		machineGunText.text = "Cost: " + machineGunUpgradeCost;
		machineGunAttack.text = "Attack: " + machineGunAttackCalculate();

		rifleText.text = "Cost: " + rifleUpgradeCost;
		rifleAttack.text = "Attack: " + rifleAttackCalculate();

		handgunText.text = "Cost: " + handgunUpgradeCost;
		handgunAttack.text = "Attack: " + handgunAttackCalculate();

		shotgunText.text = "Cost: " + shotgunUpgradeCost;
		shotgunAttack.text = "Attack: " + shotgunAttackCalculate();

		turretText.text = "Cost: " + turretUpgradeCost;
		turretAttack.text = "Turret Damage: " + turretAttackCalculate();

		consumableCost = 5000;
		healthKitCostText.text = "Cost: " + consumableCost;
		attackUpCostText.text = "Cost: " + consumableCost;
		defenseUpCostText.text = "Cost: " + consumableCost;
		speedUpCostText.text = "Cost: " + consumableCost;
		healthKitCountText.text = "Have: " + healthKitCount;
		attackUpCountText.text = "Have: " + attackUpCount;
		defenseUpCountText.text = "Have: " + defenseUpCount;
		speedUpCountText.text = "Have: " + speedUpCount;

		SaveText.text = "Press Save button to save your game progress.";

		lastScore = score;

		GameObject.FindGameObjectWithTag("PrimaryUI").SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;

		UpgradeUI.SetActive(true);
	}

	void Awake()
    {
		DontDestroyOnLoad(this.gameObject);
		if (levelInstance == null)
		{
			levelInstance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		level = 1;
		lastScore = 0;
		score = 0;
		playerHPUpgrade = 0;
		playerHPUpgradeCost = 1000;
		playerHPText.text = "Cost: " + playerHPUpgradeCost;
		PlayerMaxHP.text = "Player HP: " + PlayerHealthCalculate();
		campHPUpgrade = 0;
		campHPUpgradeCost = 1000;
		campHPText.text = "Cost: " + campHPUpgradeCost;
		CampMaxHP.text = "Camp HP: " + CampHealthCalculate();
		machineGunLevel = 0;
		machineGunUpgradeCost = 1000;
		machineGunText.text = "Cost: " + machineGunUpgradeCost;
		machineGunAttack.text = "Attack: " + machineGunAttackCalculate();
		rifleLevel = 0;
		rifleUpgradeCost = 1000;
		rifleText.text = "Cost: " + rifleUpgradeCost;
		rifleAttack.text = "Attack: " + rifleAttackCalculate();
		handgunLevel = 0;
		handgunUpgradeCost = 1000;
		handgunText.text = "Cost: " + handgunUpgradeCost;
		handgunAttack.text = "Attack: " + handgunAttackCalculate();
		shotgunLevel = 0;
		shotgunUpgradeCost = 1000;
		shotgunText.text = "Cost: " + shotgunUpgradeCost;
		shotgunAttack.text = "Attack: " + shotgunAttackCalculate();
		turretLevel = 0;
		turretUpgradeCost = 1000;
		turretText.text = "Cost: " + turretUpgradeCost;
		turretAttack.text = "Turret Damage: " + turretAttackCalculate();
		consumableCost = 5000;
		healthKitCount = 1;
		attackUpCount = 1;
		defenseUpCount = 1;
		speedUpCount = 1;
		healthKitCostText.text = "Cost: " + consumableCost;
		attackUpCostText.text = "Cost: " + consumableCost;
		defenseUpCostText.text = "Cost: " + consumableCost;
		speedUpCostText.text = "Cost: " + consumableCost;
		healthKitCountText.text = "Have: " + healthKitCount;
		attackUpCountText.text = "Have: " + attackUpCount;
		defenseUpCountText.text = "Have: " + defenseUpCount;
		speedUpCountText.text = "Have: " + speedUpCount;
		levelTime = 120f;
    }

	void Update()
    {
		if (levelTime > 0f)
        {
			levelTime -= Time.deltaTime;
		}
		if (levelTime < 0f && level < 20)
        {
			levelTime = 0f;
			LoadUpgradeScene();
        }
		if (levelTime < 0f && level == 20)
        {
			levelTime = 0f;
			LoadHighScoreScene();
		}
	}

	public void updateUpgradeText()
    {
		PlayerMaxHP.text = "Player HP: " + PlayerHealthCalculate();
		CampMaxHP.text = "Camp HP: " + CampHealthCalculate();
		SaveText.text = "Press Save button to save your game progress.";
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
			GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
		}

		if (scene.buildIndex == 5)
        {
			LoadGame();
			StartCoroutine(LoadAsynchronously());
		}
	}
}

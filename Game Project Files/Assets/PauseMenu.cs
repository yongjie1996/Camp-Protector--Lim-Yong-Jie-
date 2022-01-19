using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	private static PauseMenu pauseInstance;

	public static bool GameIsPaused = false;
	public GameObject PrimaryUI;
	public GameObject PauseMenuUI;
	public GameObject QuitUI;
	public GameObject FPS;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 3)
        {
			if (GameIsPaused && PauseMenuUI.activeSelf)
            {
				Cursor.visible = false;
				Resume();
            }
			else if (!GameIsPaused)
            {				
				Pause();
				Cursor.lockState = CursorLockMode.None;
				Cursor.lockState = CursorLockMode.Confined;
			}
        }

		if (GameIsPaused)
        {
			Cursor.visible = true;
		}
	}

	public void Resume()
    {
		if (FPS.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>() != null)
        {
			FPS.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
		}
		PrimaryUI.SetActive(true);
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void ResumeWhenQuit()
	{
		Time.timeScale = 1f;
		GameIsPaused = false;
		QuitUI.SetActive(false);
	}

	void Pause()
    {
		if (FPS.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>() != null)
		{
			FPS.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		}
		PrimaryUI.SetActive(false);
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
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
			FPS = GameObject.FindGameObjectWithTag("Player");
		}
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour {

	public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.FindGameObjectWithTag("LevelInformation")); 
        Destroy(GameObject.FindGameObjectWithTag("PlayerUI"));
    }
}

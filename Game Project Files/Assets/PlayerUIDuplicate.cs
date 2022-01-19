using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIDuplicate : MonoBehaviour {
    private static PlayerUIDuplicate playerUIInstance;
    // Use this for initialization
    private void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);

        if (playerUIInstance == null)
        {
            playerUIInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

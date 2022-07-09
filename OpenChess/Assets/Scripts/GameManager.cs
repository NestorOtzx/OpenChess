using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Mode gameMode;
    public playMode adversaryMode;

    public int defMode = 0;

    private void Awake()
    {   
        Debug.Log("Game loadedd "+gameMode.name);

        //Used when editor starts in board scene, change defMode to set a new default mode.
        if (gameMode.name == null)
        {
            gameMode = ModeManager.GetBaseMode(defMode);
        }


        //Game manager stuff xD
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneBID)
    {
        SceneManager.LoadScene(sceneBID);
    }

}

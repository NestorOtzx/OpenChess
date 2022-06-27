using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Mode gameMode;

    private void Awake()
    {   
        Debug.Log("Game loadedd "+gameMode.name);

        if (gameMode.name == null)
        {
            Debug.Log("DEf mode");
            gameMode = ModeManager.GetDefMode();
        }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static BoardGenerator boardGenerator;

    public UnityEvent onGameOver;

    public bool playingAgainstAI;

    private void Awake()
    {
        instance = this;
        boardGenerator = FindObjectOfType<BoardGenerator>(false);
    }
    public void GameOver()
    {
        Invoke("RestartScene", 2f);
        onGameOver.Invoke();
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

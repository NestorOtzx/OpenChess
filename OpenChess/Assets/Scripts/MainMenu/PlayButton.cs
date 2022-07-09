using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayButton : MonoBehaviour
{
    public ModeManager mode;
   
    public void OnClick()
    {
        GameManager.instance.adversaryMode = mode.GetPlayMode();
        GameManager.instance.gameMode = mode.GetCurrentGameMode();
        GameManager.instance.LoadScene(1);
    }

}


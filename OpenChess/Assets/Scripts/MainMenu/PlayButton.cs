using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayButton : MonoBehaviour
{
    public ModeManager mode;
   
    public void OnClick()
    {
        GameManager.instance.adversaryMode = mode.GetAdversaryMode();
        GameManager.instance.gameMode = mode.GetCurrentMode();
        GameManager.instance.LoadScene(1);
    }

}


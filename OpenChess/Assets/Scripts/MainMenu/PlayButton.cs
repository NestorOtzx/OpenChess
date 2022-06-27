using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayButton : MonoBehaviour
{
    Mode myMode;

    TextMeshProUGUI tmpro;

    private void Awake()
    {
        tmpro = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Init(Mode modeToPlay)
    {
        myMode = modeToPlay;
        tmpro.text = modeToPlay.name;
    }


    public void OnClick()
    {
        GameManager.instance.gameMode = myMode;
        GameManager.instance.LoadScene(1);
    }

}


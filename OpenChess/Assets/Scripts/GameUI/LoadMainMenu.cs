using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.instance.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static BoardGenerator boardGenerator;


    private void Awake()
    {
        instance = this;
        boardGenerator = FindObjectOfType<BoardGenerator>(false);
    }

}

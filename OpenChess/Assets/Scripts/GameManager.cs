using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Square> boardSquares = new List<Square>();

    public static GameManager instance;

    public int boardX;
    public int boardY;


    private void Awake()
    {
        instance = this;
    }

}

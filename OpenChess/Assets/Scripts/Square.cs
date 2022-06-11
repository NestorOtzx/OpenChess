using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool isOcuped;
    public bool isAvailable = false;
    public int squareID;



    private void Start()
    {
        squareID = GameManager.instance.boardSquares.Count;
        GameManager.instance.boardSquares.Add(this);
    }

}

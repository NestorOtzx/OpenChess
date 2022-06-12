using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Queen
{
    public override void SetAvailableSquares(ref Square[,] squares, Vector2Int pos)
    {
        Debug.Log(squares[1, 2].isOcuped);

        AvailableDiagonal(squares, pos);
    }
}

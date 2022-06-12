using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Queen
{
    public override void SetAvailableSquares(ref Square[,] squares, Vector2Int pos)
    {
        //Available to:
        AvailableHorizontalVertical(squares, pos);
    }

}

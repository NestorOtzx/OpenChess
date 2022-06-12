using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPawn : WhitePawn
{
    public override void SetAvailableSquares(ref Square[,] squares, Vector2Int pos)
    {
        try
        {
            if (!squares[pos.x, pos.y - 1].isOcuped)
            {
                AvailableSquare(squares[pos.x, pos.y - 1]);

                if (firstMove)
                {
                    AvailableSquare(squares[pos.x, pos.y - 2]);
                }    
            }
            
            //This allows the pawn to capture pieces diagonally
            if (squares[pos.x+1, pos.y - 1].isOcuped)
            {
                AvailableSquare(squares[pos.x+1, pos.y - 1]);
            }
            if (squares[pos.x-1, pos.y - 1].isOcuped)
            {
                AvailableSquare(squares[pos.x-1, pos.y - 1]);
            }
        }catch
        {
            //Nothing
        }
    }

}

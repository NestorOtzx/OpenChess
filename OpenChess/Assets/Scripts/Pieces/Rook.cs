using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override void SetAvailableSquares()
    {
        Square[,] squares = GameManager.boardGenerator.squares;
        Vector2Int pos = currentSquare.squarePos;

        //Available to:
        //Right
        for (int i = pos.x+1; i<squares.GetLength(0); i++)
        {
            AvailableSquare(squares[i, pos.y]);
            if (squares[i,pos.y].isOcuped)
            {
                break;
            }
        }
        //Left
        for (int i = pos.x-1; i >= 0; i--)
        {
            AvailableSquare(squares[i, pos.y]);
            if (squares[i, pos.y].isOcuped)
            {
                break;
            }
        }
        //Up
        for (int i = pos.y+1; i < squares.GetLength(1); i++)
        {
            AvailableSquare(squares[pos.x, i]);
            if (squares[pos.x, i].isOcuped)
            {
                break;
            }
        }
        //Down
        for (int i = pos.y-1; i >= 0; i--)
        {
            AvailableSquare(squares[pos.x, i]);
            if (squares[pos.x, i].isOcuped)
            {
                break;
            }
        }
    }

}

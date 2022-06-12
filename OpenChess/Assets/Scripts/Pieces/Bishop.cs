using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override void SetAvailableSquares()
    {
        Square[,] squares = GameManager.boardGenerator.squares;
        Vector2Int pos = currentSquare.squarePos;

        //Available to:
        int x = pos.x;
        int y = pos.y;


        //UP-RIGHT
        while(true)
        {
            x++;
            y++;



            AvailableSquare(squares[x, y]);
            if (x >= squares.GetLength(0)-1 || y >= squares.GetLength(1)-1)
            {
                break;
            }
        }

        x = pos.x;
        y = pos.y;

        //UP-LEFT
        while (true)
        {

            Debug.Log(x + "| " + y);

            AvailableSquare(squares[x, y]);
            if (x < 1 || y >= squares.GetLength(1)-1)
            {
                break;
            }

        }

        x = pos.x;
        y = pos.y;

        //Down-Right
        while (true)
        {
            x++;
            y--;

            AvailableSquare(squares[x, y]);
            if (x >= squares.GetLength(0)-1 || y < 1)
            {
                break;
            }
        }

        x = pos.x;
        y = pos.y;

        //Down-left
        while (true)
        {
            x--;
            y--;

            AvailableSquare(squares[x, y]);
            if (x < 1 || y < 1)
            {
                break;
            }
        }

    }
}

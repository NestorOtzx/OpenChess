using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override void SetAvailableSquares(ref Square[,] squares, Vector2Int pos)
    {
        AvailableHorizontalVertical(squares, pos);
        AvailableDiagonal(squares, pos);
    }

    protected void AvailableHorizontalVertical(Square [,] squares, Vector2Int pos)
    {
        int[] modifiers = new int[2];

        modifiers[0] = 1;
        modifiers[1] = -1;


        for (int t = 0; t < 2; t++)
        {
            for (int i = pos.x + modifiers[t]; i < squares.GetLength(0) && i >= 0; i += modifiers[t])
            {
                AvailableSquare(squares[i, pos.y]);
                if (squares[i, pos.y].isOcuped)
                {
                    break;
                }
            }
            for (int i = pos.y + modifiers[t]; i < squares.GetLength(1) && i >= 0; i += modifiers[t])
            {
                AvailableSquare(squares[pos.x, i]);
                if (squares[pos.x, i].isOcuped)
                {
                    break;
                }
            }
        }
    }

    protected void AvailableDiagonal(Square [,] squares, Vector2Int pos)
    {
        Vector2Int[] modifiers = new Vector2Int[4];

        //This sets all directions
        modifiers[0] = new Vector2Int(1, 1);
        modifiers[1] = new Vector2Int(1, -1);
        modifiers[2] = new Vector2Int(-1, 1);
        modifiers[3] = new Vector2Int(-1, -1);

        for (int i = 0; i < modifiers.Length; i++)
        {
            int x = pos.x;
            int y = pos.y;

            while (true)
            {
                x += modifiers[i].x;
                y += modifiers[i].y;

                if (x >= 0 && y >= 0 && x < squares.GetLength(0) && y < squares.GetLength(1))
                {
                    AvailableSquare(squares[x, y]);

                    if (squares[x, y].isOcuped)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

    }

}

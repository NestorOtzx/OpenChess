using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override void SetAvailableSquares()
    {
        Square[,] squares = GameManager.boardGenerator.squares;
        Vector2Int pos = currentSquare.squarePos;

        Vector2Int []modifiers = new Vector2Int[4];

        //This sets all directions
        modifiers[0] = new Vector2Int(1, 1);
        modifiers[1] = new Vector2Int(1, -1);
        modifiers[2] = new Vector2Int(-1, 1);
        modifiers[3] = new Vector2Int(-1, -1);

        for (int i = 0; i<modifiers.Length; i++)
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

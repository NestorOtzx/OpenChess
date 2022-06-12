using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override void SetAvailableSquares(ref Square[,] squares, Vector2Int pos)
    {
        Vector2Int[] directions = new Vector2Int[8];

        //Front
        directions[0] = new Vector2Int(-1, 2);
        directions[1] = new Vector2Int(1, 2);
        
        //left
        directions[2] = new Vector2Int(-2, 1);
        directions[3] = new Vector2Int(-2, -1);

        //Right
        directions[4] = new Vector2Int(2, 1);
        directions[5] = new Vector2Int(2, -1);
        
        //Down
        directions[6] = new Vector2Int(-1, -2);
        directions[7] = new Vector2Int(1, -2);

        for (int i = 0; i < directions.Length; i++)
        {
            int x = pos.x + directions[i].x;
            int y = pos.y + directions[i].y;

            if (x >= 0 && y >= 0 && x < squares.GetLength(0) && y < squares.GetLength(1))
                AvailableSquare(squares[x, y]);
        }
    }
}

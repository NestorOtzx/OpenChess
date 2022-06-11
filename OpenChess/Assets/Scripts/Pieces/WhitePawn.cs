using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawn : Piece
{
    
    protected bool firstMove = true;

    public override void SetAvailableSquares()
    {
        Square[,] squares = GameManager.boardGenerator.squares;
        Vector2Int pos = currentSquare.squarePos;

        AvailableSquare(squares[pos.x, pos.y + 1]);

        if (firstMove)
        {
            try
            {
                AvailableSquare(squares[pos.x, pos.y + 2]);
            }
            catch
            {
                //Do nothing
            }
        }
    }

    protected override void OnPieceMoved(Square _square)
    {
        base.OnPieceMoved(_square);
        firstMove = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    //This indicates the pawn the direction he should move, this diferences the black pawn from de white pawn
    public Vector2Int directionToMove = new Vector2Int(0, 1);

    public Vector2Int [] placesToAttack = new Vector2Int[2];

    protected bool firstMove = true;
    public override void SetAvailableSquares(ref Square[,] squares, Vector2Int pos)
    {
        try
        {
            if (!squares[pos.x + directionToMove.x, pos.y + directionToMove.y].isOcuped)
            {
                AvailableSquare(squares[pos.x+directionToMove.x, pos.y + directionToMove.y]);

                if (firstMove)
                {
                    AvailableSquare(squares[pos.x+directionToMove.x*2, pos.y + directionToMove.y*2]);
                }    
            }
            
            //This allows the pawn to capture pieces diagonally using placesToAttack
            for (int i = 0; i<placesToAttack.Length; i++)
            {
                if (squares[pos.x + placesToAttack[i].x, pos.y + placesToAttack[i].y].isOcuped)
                {
                    AvailableSquare(squares[pos.x + placesToAttack[i].x, pos.y + placesToAttack[i].y]);
                }
            }
        }catch
        {
            Debug.Log("ERROR MOVING PAWN");
            //Nothing
        }
        
    }


    protected override void OnPieceMoved(Square _square)
    {
        base.OnPieceMoved(_square);
        firstMove = false;
    }

}

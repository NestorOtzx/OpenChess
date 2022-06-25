using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rules 
{
    public static List<Square> GetMainRulesFor(Piece piece)
    {
        switch(piece.type)
        {
            case TypeOfPieces.pawn:
                return PawnMoveRules(piece);
            default:
                return null;
        }
    }

    public static bool MovementCompliesWithRules(Piece piece, Square squareToMove)
    {
        switch(piece.type)
        {
            case TypeOfPieces.pawn:
                return PawnRules(piece, squareToMove);
            default:
                return true;

        }
    }

    static bool PawnRules(Piece pawn, Square squareToMove)
    {
        bool valid = true;

        int x = pawn.currentPos.x;
        int y = pawn.currentPos.y;

        if (x == squareToMove.squarePos.x && squareToMove.isOccupied)
        {
            valid = false;
        }

        return valid;
    }


    static List<Square> PawnMoveRules(Piece pawn)
    {
        List<Square> all = new List<Square>();

        int x = pawn.currentPos.x;
        int y = pawn.currentPos.y;

        if (BoardManager.CheckBoardPos(x + 1, y + pawn.basicMoves[0].y))
        {
            Square squareToKill = BoardManager.board[x + 1, y + pawn.basicMoves[0].y];
            if (squareToKill.isOccupied && squareToKill.currentPiece.team != pawn.team)
            {
                all.Add(squareToKill);
            }
        }

        if (BoardManager.CheckBoardPos(x - 1, y + pawn.basicMoves[0].y))
        {
            Square squareToKill = BoardManager.board[x - 1, y + pawn.basicMoves[0].y];
            if (squareToKill.isOccupied && squareToKill.currentPiece.team != pawn.team)
            {
                all.Add(squareToKill);
            }
        }

        if (pawn.info.timesMoved == 0)
        {
            Square square = BoardManager.board[x, y + pawn.basicMoves[0].y * 2];
            Square prevSquare = BoardManager.board[x, y + pawn.basicMoves[0].y];

            if (BoardManager.CheckBoardPos(x,y) && PawnRules(pawn, square) && PawnRules(pawn, prevSquare))
                all.Add(square);
        }

        return all;
    }
}

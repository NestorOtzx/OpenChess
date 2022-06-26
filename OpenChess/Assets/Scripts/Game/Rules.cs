using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rules 
{
    //----------------COMPLIES WITH RULES--------------------
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

    //--------------MOVEMENT RULES----------------
    public static List<Square> GetMainRulesFor(Piece piece)
    {
        switch (piece.type)
        {
            case TypeOfPieces.pawn:
                return PawnMoveRules(piece);
            case TypeOfPieces.king:
                return KingMoveRules(piece);
            default:
                return null;
        }
    }
    static List<Square> KingMoveRules(Piece king)
    {
        List<Square> all = new List<Square>();

        int x = king.currentPos.x;
        int y = king.currentPos.y;

        if (king.info.timesMoved == 0)
        {
            if (BoardManager.CheckBoardPos(x - 3, y) && BoardManager.CheckBoardPos(x - 2, y) && BoardManager.CheckBoardPos(x - 1, y))
            {
                Square rookSquare = BoardManager.board[x - 3, y];
                Square newKingSquare = BoardManager.board[x - 2, y];
                Square newRookSquare = BoardManager.board[x - 1, y];

                if (newKingSquare.currentPiece == null && newRookSquare.currentPiece == null &&
                    rookSquare.currentPiece != null && rookSquare.currentPiece.info.timesMoved == 0 && rookSquare.currentPiece.type == TypeOfPieces.rook)
                {
                    all.Add(BoardManager.board[x - 2, y]);
                }
            }
        }

        return all;
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

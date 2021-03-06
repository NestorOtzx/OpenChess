using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Piece : MonoBehaviour
{
    public TypeOfPieces type;
    
    public TEAM team;
    
    public Vector2Int currentPos;

    public Square currentSquare;

    //Moves piece can do
    public Vector2Int[] basicMoves;

    //Times to repeat each basic move, useful to do rook or bishop moves
    public uint repeatBasicMove = 1;

    public PieceInfo info = new PieceInfo();


    public List<Square> GetPossibleMoves()
    {
        List<Square> all = new List<Square>();

        List<Square> ruleMovements = Rules.GetMainRulesFor(this);

        if (ruleMovements != null)
            all.AddRange(ruleMovements);

        List<Vector2Int> currentMoves = new List<Vector2Int>(basicMoves);

        for (int repetition = 1; repetition <= repeatBasicMove; repetition++)
        {
            List<Vector2Int> unabailableSquares = new List<Vector2Int>();

            for (int i = 0; i < currentMoves.Count; i++)
            {
                Vector2Int movePosition = new Vector2Int(currentPos.x + (currentMoves[i].x * repetition), currentPos.y + (currentMoves[i].y * repetition));

                if (BoardManager.CheckBoardPos(movePosition.x, movePosition.y))
                {
                    Square squareToAdd = BoardManager.board[movePosition.x, movePosition.y];

                    if (squareToAdd.isOccupied)
                    {
                        if (squareToAdd.currentPiece.team != team && Rules.MovementCompliesWithRules(this, squareToAdd))
                        {
                            all.Add(squareToAdd);
                        }

                        unabailableSquares.Add(currentMoves[i]);
                        continue;
                    }

                    if (Rules.MovementCompliesWithRules(this, squareToAdd))
                    {
                        all.Add(squareToAdd);
                    }
                }
            }

            for(int i = 0; i<unabailableSquares.Count; i++)
            {
                currentMoves.Remove(unabailableSquares[i]);

            }
        }

        return all;
    }

    //Move this peace to square
    public void Move(Square squareToMove)
    {
        currentSquare.isOccupied = false;
        currentSquare.currentPiece = null;

        transform.parent = squareToMove.transform;
        transform.position = squareToMove.transform.position;
        currentPos = squareToMove.squarePos;


        if (squareToMove.currentPiece != null && squareToMove.currentPiece.team != team)
        {
            PiecesGenerator.allPieces.Remove(squareToMove.currentPiece.gameObject);
            DestroyImmediate(squareToMove.currentPiece.gameObject);
            squareToMove.currentPiece = null;
        }

        currentSquare = squareToMove;
        currentSquare.isOccupied = true;
        currentSquare.currentPiece = this;

        info.timesMoved++;

        //Next team turn
        TeamManager.NextTeamTurn();
    }
}

//Useful information of this piece
public class PieceInfo
{
    public int timesMoved = 0;
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public TEAM IAteam;

    public List<Piece> myPieces = new List<Piece>();

    private void Start()
    {
        Piece [] all = FindObjectsOfType<Piece>();

        for (int i = 0; i<all.Length; i++)
        {
            if (all[i].team == IAteam)
            {
                myPieces.Add(all[i]);
            }
        }
    }


    private void Update()
    {
        if (TurnManager.currentTeamTurn == IAteam)
        {
            RemoveDeadPieces();
            Play();
        }
    }

    void RemoveDeadPieces()
    {
        myPieces.RemoveAll(item => item == null);
    }

    void Play()
    {
        Square [] squares = null;

        Piece pieceToMove = null;

        List<Piece> piecesCanMove = new List<Piece>(myPieces);


        while (squares == null)
        {
            if (piecesCanMove.Count < 1)
            {
                Debug.LogError("NO MOVES");
                return;
            }

            int piec = Random.Range(0, piecesCanMove.Count);

            pieceToMove = piecesCanMove[piec];

            squares =  pieceToMove.GetPossibleMoves().ToArray();

            if (squares.Length < 1)
            {
                piecesCanMove.Remove(pieceToMove);
                squares = null;
            }
        }

        
        int sqreID = Random.Range(0, squares.Length);


        Square squareToMove = squares[sqreID];
        Debug.Log("Move " + pieceToMove.name + " in: " + pieceToMove.currentPos + " to " + squareToMove.squarePos);

        pieceToMove.Move(squareToMove);

    }

}

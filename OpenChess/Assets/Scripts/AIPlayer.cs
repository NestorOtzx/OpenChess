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
            Play();
        }
    }

    void Play()
    {
        Square [] squares = null;

        Piece pieceToMove = null;

        while (squares == null)
        {
            pieceToMove = myPieces[Random.Range(0, myPieces.Count)];

            squares =  pieceToMove.GetPossibleMoves().ToArray();

            if (squares.Length < 1)
            {
                squares = null;
            }
        }

        
        int sqreID = Random.Range(0, squares.Length);

        Square squareToMove = squares[sqreID];

        pieceToMove.Move(squareToMove);

    }

}

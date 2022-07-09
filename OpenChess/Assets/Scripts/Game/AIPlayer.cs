using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public List<TEAM> team; //All teams controled by AI

    //Pieces of each team  controled by AI
    public Dictionary<TEAM, List<Piece>> myPieces = new Dictionary<TEAM, List<Piece>>();

    private void Start()
    {
        GetMyPieces();
    }

    private void Update()
    {
        if (team.Contains(TeamManager.currentTeamTurn))
        {
            RemoveDeadPieces();
            Play();
        }
    }

    private void GetMyPieces()
    {
        Piece[] all = FindObjectsOfType<Piece>();

        for (int i = 0; i < team.Count; i++)
        {
            List<Piece> currentTeamPieces = new List<Piece>();

            for (int j = 0; j < all.Length; j++)
            {
                if (all[j].team == team[i])
                {
                    currentTeamPieces.Add(all[j]);
                }
            }

            myPieces.Add(team[i], currentTeamPieces);
        }
    }

    //Remove dead pieces from myPieces
    void RemoveDeadPieces()
    {
        myPieces[TeamManager.currentTeamTurn].RemoveAll(item => item == null);
    }

    void Play()
    {
        Square [] squares = null;

        Piece pieceToMove = null;

        List<Piece> piecesCanMove = new List<Piece>(myPieces[TeamManager.currentTeamTurn]);

        //Select a random move
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
        //Debug.Log("Move " + pieceToMove.name + " in: " + pieceToMove.currentPos + " to " + squareToMove.squarePos);
        pieceToMove.Move(squareToMove);

    }

}

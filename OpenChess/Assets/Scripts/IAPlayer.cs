using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPlayer : Player
{
    List<Piece> myPieces = new List<Piece>();

    private void Start()
    {
        Piece[] allPieces = FindObjectsOfType<Piece>();

        for (int i = 0; i<allPieces.Length; i++)
        {
            if (allPieces[i].team == currentTeam)
            {
                myPieces.Add(allPieces[i]);
            }
        }
    }

    private void Update()
    {
        //Do nothing
    }

    void AnalizePieces()
    {
        for (int i = 0; i<myPieces.Count; i++)
        {
            if (myPieces[i] == null)
            {
                LosePiece(myPieces[i]);
            }
        }

    }

    public override void Play()
    {
        Debug.Log("IA PLAY WUUUUU :DDD");
        AnalizePieces();
        //PlayRandomly();
        SelectMove();

    }

    void SelectMove()
    {
        int currentPoints = GameScore.pointsByTeam[currentTeam];

        int enemyPoints = GameScore.pointsByTeam[Team.White]; //This is not definitive

        //This try to leave enemy points lower as possible
        Square bestSquare = null;

        int bestPiece = -1;
        int enemyPointsAux = enemyPoints;

        for (int i = 0; i<myPieces.Count; i++)
        {
            myPieces[i].OnBeingGrabbed();

            for (int j = 0; j<myPieces[i].availableSquares.Count; j++)
            {
                Square currentSquare = myPieces[i].availableSquares[j];
                Piece pieceToKill = currentSquare.currentPiece;

                if (pieceToKill && pieceToKill.team != currentTeam)
                {
                    if (enemyPoints - currentSquare.currentPiece.valueOnTheBoard < enemyPointsAux)
                    {
                        bestSquare = currentSquare;
                        enemyPointsAux = enemyPoints - currentSquare.currentPiece.valueOnTheBoard;
                        bestPiece = i;
                    }
                }
            }

            myPieces[i].UnavailableSquares();
        }

        if (enemyPointsAux < enemyPoints)
        {
            myPieces[bestPiece].OnBeingGrabbed();
            myPieces[bestPiece].OnBeingDropped(bestSquare);
        }
        else
        {
            PlayRandomly();
        }



    }

    void PlayRandomly()
    {
        Square squareToPutPiece = null;

        while(squareToPutPiece == null)
        {
            int randomPiece = Random.Range(0, myPieces.Count - 1);

            Piece pieceToMove = myPieces[randomPiece];
            pieceToMove.OnBeingGrabbed();

            if (pieceToMove.availableSquares.Count > 0)
            {
                int randomSquare = Random.Range(0, pieceToMove.availableSquares.Count - 1);

                Debug.Log("pieceIndex: " + randomPiece + " squareIndex: " + randomSquare);

                squareToPutPiece = pieceToMove.availableSquares[randomSquare];

                if (squareToPutPiece.isOcuped && squareToPutPiece.currentPiece.team == currentTeam)
                {
                    squareToPutPiece = null;
                }
            }

            pieceToMove.OnBeingDropped(squareToPutPiece);
        }
    }

    public void LosePiece(Piece piece)
    {
        myPieces.Remove(piece);
    }

}

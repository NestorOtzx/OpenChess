using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TypeOfPiece
{
    Pawn, King, Queen, Knight, Rook, Bishop
}

public enum Team
{
    White, Black
}

public class Piece : MonoBehaviour
{
    protected Square currentSquare;

    public List<Square> availableSquares = new List<Square>();

    public Team team;

    //This is useful for the AI to identify the best move.
    public int valueOnTheBoard = 10;

    private void Start()
    {
        currentSquare = transform.parent.GetComponent<Square>();
        currentSquare.isOcuped = true;
        currentSquare.currentPiece = this;

        GameScore.pointsByTeam[team] += valueOnTheBoard;

    }

    public virtual void SetAvailableSquares(ref Square [,] squares, Vector2Int pos)
    {
        try
        {
            AvailableSquare(squares[pos.x, pos.y + 1]);
        }
        catch
        {
            //Do NOTHING
        }
    }

    protected void AvailableSquare(Square _square)
    {
        _square.isAvailable = true;
        availableSquares.Add(_square);
    }

    public virtual void UnavailableSquares()
    {
        for (int i = 0; i<availableSquares.Count; i++)
        {
            availableSquares[i].isAvailable = false;
        }

        availableSquares.Clear();
    }
    
    public virtual void OnBeingGrabbed()
    {
        Square[,] squares = GameManager.boardGenerator.squares;
        Vector2Int pos = currentSquare.squarePos;


        if (team == TurnManager.GetCurrentTeam())
            SetAvailableSquares(ref squares, pos);
    }

    public virtual void OnBeingDropped(Square squareDroped)
    {
        //avoid to lose this information before UnavailableSquares()
        bool availableAux = false;
        if (squareDroped)
            availableAux= squareDroped.isAvailable;

        UnavailableSquares();

        if (squareDroped == currentSquare)
        {
            PutPieceOnBoard();
            return;
        }

        if (squareDroped != null && availableAux)
        {
            //If the piece is free or you can capture
            if (!squareDroped.isOcuped || (squareDroped.isOcuped && Capture(squareDroped)))
            {
                OnPieceMoved(squareDroped);
            }
        }

        PutPieceOnBoard();
    }

    protected void PutPieceOnBoard()
    {
        transform.position = currentSquare.transform.position;
        transform.parent = currentSquare.transform;
        currentSquare.currentPiece = this;
    }

    protected virtual bool Capture(Square _square)
    {

        Piece pieceToKill = _square.currentPiece;
        if (pieceToKill && pieceToKill.team != team)
        {
            pieceToKill.OnBeingCaptured();
            Destroy(pieceToKill.gameObject);
            return true;
        }
        return false;
    }

    public virtual void OnBeingCaptured()
    {
        if (team == Team.Black)
            Debug.Log("I LOST A PIECE D:");
        GameScore.pointsByTeam[team] -= valueOnTheBoard;
        currentSquare.currentPiece = null;
    }

    protected virtual void OnPieceMoved(Square _square)
    {
        currentSquare.isOcuped = false;
        currentSquare.currentPiece = null;
        currentSquare = _square;
        currentSquare.isOcuped = true;
        TurnManager.NextTeam();
    }


}

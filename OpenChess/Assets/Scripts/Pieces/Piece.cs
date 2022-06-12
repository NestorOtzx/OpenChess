using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TypeOfPiece
{
    Pawn, King, Queen, Knight, Rook, Bishop
}

public enum TeamOfPiece
{
    White, Black
}

public class Piece : MonoBehaviour
{
    protected Square currentSquare;

    List<Square> availableSquares = new List<Square>();

    public TeamOfPiece team;

    private void Start()
    {
        currentSquare = transform.parent.GetComponent<Square>();
        currentSquare.isOcuped = true;
    }

    public virtual void SetAvailableSquares()
    {
        Square[,] squares = GameManager.boardGenerator.squares;
        Vector2Int pos = currentSquare.squarePos;

        AvailableSquare(squares[pos.x, pos.y + 1]);
    }

    protected void AvailableSquare(Square _square)
    {
        _square.isAvailable = true;
        availableSquares.Add(_square);
    }

    public virtual void UnavialableSquares()
    {
        for (int i = 0; i<availableSquares.Count; i++)
        {
            availableSquares[i].isAvailable = false;
            availableSquares.Remove(availableSquares[i]);
        }
    }
    
    public virtual void OnBeingGrabbed()
    {
        SetAvailableSquares();
    }

    public virtual void OnBeingDropped(Square squareDroped)
    {
        //avoid to lose this information before UnavailableSquares()
        bool availableAux = false;
        if (squareDroped)
            availableAux= squareDroped.isAvailable;

        UnavialableSquares();

        if (squareDroped != null && availableAux)
        {
            if (squareDroped.isOcuped)
            {
                Capture(squareDroped);
            }

            OnPieceMoved(squareDroped);
        }
        
        transform.position = currentSquare.transform.position;
        transform.parent = currentSquare.transform;
    }

    protected virtual void Capture(Square _square)
    {
        Piece pieceToKill = _square.GetComponentInChildren<Piece>();
        if (pieceToKill)
        {
            Destroy(pieceToKill.gameObject);
        }
    }

    protected virtual void OnPieceMoved(Square _square)
    {
        currentSquare.isOcuped = false;
        currentSquare = _square;
        currentSquare.isOcuped = true;
    }


}
